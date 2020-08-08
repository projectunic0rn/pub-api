using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.DTOs.GitHubDTOs;
using Microsoft.Extensions.Configuration;

namespace CommunicationAppDomain.Services
{
    public class GitHubService
    {
        private readonly Http _http = new Http();
        private readonly string _baseUri = "https://api.github.com";
        public readonly string GithubOrganzationName;
        private Dictionary<string, string> headers = new Dictionary<string, string>();
        public GitHubAuthService _githubAuthService;

        public GitHubService()
        {
            _githubAuthService = new GitHubAuthService();
            GithubOrganzationName = AppSettings.GitHubOrganization;
            // add default headers for all github api calls
            headers.Add("Accept", "application/vnd.github.v3+json");
            headers.Add("User-Agent", GithubOrganzationName);
        }

        public async Task<OrganizationMembershipDto> InviteToGithubOrg(string githubUsername)
        {
            await UpdateAuthHeader();
            var organizationMembership = await _http.Put<OrganizationMembershipDto>($"{_baseUri}/orgs/{GithubOrganzationName}/memberships/{githubUsername}", headers);
            return organizationMembership;
        }

        private async Task UpdateAuthHeader()
        {
            string _installationAccessToken = await _githubAuthService.GetInstallationAccessToken();
            if (headers.ContainsKey("Authorization"))
            {
                headers["Authorization"] = $"Bearer {_installationAccessToken}";
            }
            else
            {
                headers.Add("Authorization", $"Bearer {_installationAccessToken}");
            }
        }
    }
}
