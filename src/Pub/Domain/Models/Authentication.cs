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

namespace Domain.Models
{
    public class Authentication: IAuthentication
    {
        private readonly IMapper _mapper;
        private User _user;
        private readonly IStorage<UserEntity> _storage;
        PasswordHasher<User> _passwordHasher;

        public Authentication()
        {
            _user = new User();
            _storage = new UserEntity();
            _mapper = new InitializeMapper().GetMapper;
            _passwordHasher = new PasswordHasher<User>();
        }
        
        public async Task<JsonWebTokenDto> LoginUserAsync(LoginDto login)
        {
            JsonWebTokenDto jsonWebToken;
            PasswordVerificationResult verificationResult;
            
            var user = await _storage.FindAsync(m => m.Username == login.Username);
            verificationResult = ValidatePassword(_user, user.HashedPassword, login.Password);
            jsonWebToken = GenerateJsonWebToken(new JwtUserClaimsDto(user.Id.ToString()));

            switch (verificationResult)
            {
                case PasswordVerificationResult.Success:
                    return jsonWebToken;
                case PasswordVerificationResult.Failed:
                    throw new AuthenticationException(ExceptionMessage.InvalidCredentials);
                case PasswordVerificationResult.SuccessRehashNeeded:
                    user.HashedPassword = HashPassword(_user, login.Password);
                    await user.UpdateAsync(user);
                    return jsonWebToken;
                default:
                    throw new AuthenticationException(ExceptionMessage.ExceptionThrown);
            }
        }

        public async Task<JsonWebTokenDto> RegisterUserAsync(RegistrationDto registration)
        {
            if(registration.Password != registration.PasswordConfirmation)
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