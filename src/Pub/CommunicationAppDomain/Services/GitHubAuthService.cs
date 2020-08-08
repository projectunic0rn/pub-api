using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.DTOs.GitHubDTOs;
using CommunicationAppDomain.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CommunicationAppDomain.Services
{
    public class GitHubAuthService
    {
        private readonly Http _http = new Http();
        private readonly string _githubAppId;
        private readonly string _githubAppInstallationId;
        private readonly string _githubOrganization;
        private readonly string _baseAuthUri = "https://api.github.com/app/installations";
        private string _installationAccessToken;
        private DateTimeOffset _installationAccessTokenExpirationTime;
        private readonly string _githubRSAPrivateKey;
        private string _githubJwtToken;
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

        public GitHubAuthService()
        {
            _githubOrganization = AppSettings.GitHubOrganization;
            _githubAppId = AppSettings.GitHubAppId;
            _githubAppInstallationId = AppSettings.GitHubAppInstallationId;
            _githubRSAPrivateKey = AppSettings.GitHubAppPrivateRSAKey;
            _installationAccessTokenExpirationTime = DateTime.MinValue;
            // add default headers for all github api calls
            _headers.Add("Accept", "application/vnd.github.machine-man-preview+json");
            _headers.Add("User-Agent", _githubOrganization);
        }

        public async Task<string> GetInstallationAccessToken()
        {
            if (DateTime.UtcNow > _installationAccessTokenExpirationTime)
            {
                _githubJwtToken = GenerateGithubJwt();
                UpdateAuthHeader();
                var accessToken = await _http.Post<AccessTokenDto>($"{_baseAuthUri}/{_githubAppInstallationId}/access_tokens", _headers, "");
                _installationAccessTokenExpirationTime = DateTimeOffset.Parse(accessToken.ExpiresAt);
                AppSettings.GitHubInstallationAccessToken = accessToken.Token;
                return accessToken.Token;
            }
            else
            {
                _installationAccessToken = AppSettings.GitHubInstallationAccessToken;
                return _installationAccessToken;
            }
        }

        private string GenerateGithubJwt()
        {
            RsaSecurityKey privateKey;
            RSA privateRsa = RSA.Create();
            privateRsa.FromXmlString(_githubRSAPrivateKey);
            privateKey = new RsaSecurityKey(privateRsa);
            var creds = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);

            var token = new JwtSecurityToken(
                issuer: _githubAppId,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: creds);
            token.Payload["iat"] = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
        
        private void UpdateAuthHeader()
        {
            if (_headers.ContainsKey("Authorization"))
            {
                _headers["Authorization"] = $"Bearer {_githubJwtToken}";
            }
            else
            {
                _headers.Add("Authorization", $"Bearer {_githubJwtToken}");
            }
        }
    }
}
