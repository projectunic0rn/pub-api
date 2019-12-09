using Common.Contracts;
using Common.DTOs;
using System;
using AutoMapper;
using Infrastructure.Persistence.Entities;
using Domain.MappingConfig;
using System.Threading.Tasks;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Common.AppSettings;
using Newtonsoft.Json.Serialization;
using Domain.Exceptions;
using Common.Models;

namespace Domain.Models
{
    public class Authentication : IAuthentication
    {
        private readonly IMapper _mapper;
        private User _user;
        private readonly IStorage<UserEntity> _storage;
        private readonly PasswordHasher<User> _passwordHasher;

        public Authentication()
        {
            _user = new User();
            _storage = new UserEntity();
            _mapper = new InitializeMapper().GetMapper;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<JsonWebTokenDto> LoginUserAsync(LoginDto login)
        {
            PasswordVerificationResult verificationResult;
            UserEntity user;
            bool magicTokenLoginMethod = login.Email == "token";

            if (magicTokenLoginMethod)
            {
                // user has logged in via a workspace command 
                // so log them in by validating against stored token
                string magicToken = login.Password;
                user = await _storage.FindAsync(m => m.MagicLoginToken == magicToken);
            }
            else
            {
                user = await _storage.FindAsync(m => m.Email == login.Email);
            }

            if (user == null)
            {
                throw new AuthenticationException(ExceptionMessage.InvalidCredentials);
            }

            if (magicTokenLoginMethod)
            {
                bool magicTokenNotExpired = DateTimeOffset.Compare(user.MagicLoginTokenExpiresAt, DateTimeOffset.Now) > 0;
                if (magicTokenNotExpired)
                {
                    verificationResult = PasswordVerificationResult.Success;
                }
                else
                {
                    verificationResult = PasswordVerificationResult.Failed;
                }
            }
            else
            {
                verificationResult = ValidatePassword(_user, user.HashedPassword, login.Password);
            }

            switch (verificationResult)
            {
                case PasswordVerificationResult.Success:
                    return GenerateJsonWebToken(new JwtUserClaimsDto(user.Id.ToString()));
                case PasswordVerificationResult.Failed:
                    throw new AuthenticationException(ExceptionMessage.InvalidCredentials);
                case PasswordVerificationResult.SuccessRehashNeeded:
                    user.HashedPassword = HashPassword(_user, login.Password);
                    await user.UpdateAsync(user);
                    return GenerateJsonWebToken(new JwtUserClaimsDto(user.Id.ToString()));
                default:
                    throw new AuthenticationException(ExceptionMessage.ExceptionThrown);
            }
        }

        public async Task<JsonWebTokenDto> RegisterUserAsync(RegistrationDto registration)
        {
            if (registration.Password != registration.PasswordConfirmation)
            {
                throw new AuthenticationException(ExceptionMessage.NonMatchingPasswords);
            }

            JsonWebTokenDto jsonWebToken;
            _user = new User(registration.Username, registration.Email, registration.Timezone, registration.Locale, true);

            var userEntity = _mapper.Map<UserEntity>(_user);
            userEntity.HashedPassword = HashPassword(_user, registration.Password);
            await _storage.CreateAsync(userEntity);
            jsonWebToken = GenerateJsonWebToken(new JwtUserClaimsDto(userEntity.Id.ToString()));

            return jsonWebToken;
        }

        private PasswordVerificationResult ValidatePassword(User user, string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }

        private string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public JsonWebTokenDto GenerateJsonWebToken(object jwtTokenData)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(jwtTokenData, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }), null)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: AppSettings.JwtIssuer,
                audience: AppSettings.JwtAudience,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            JsonWebTokenDto jsonWebToken = new JsonWebTokenDto(jwtToken);
            return jsonWebToken;
        }

    }
}