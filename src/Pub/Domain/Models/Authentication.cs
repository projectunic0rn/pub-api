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
using Domain.Helpers;

namespace Domain.Models
{
    public class Authentication : IAuthentication
    {
        private readonly IMapper _mapper;
        private Common.Models.User _user;
        private readonly IStorage<UserEntity> _storage;
        private readonly PasswordHasher<Common.Models.User> _passwordHasher;
        private readonly INotifier _notifier;
        public Authentication(INotifier notifier)
        {
            _user = new Common.Models.User();
            _storage = new UserEntity();
            _mapper = new InitializeMapper().GetMapper;
            _passwordHasher = new PasswordHasher<Common.Models.User>();
            _notifier = notifier;
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
            _user = new Common.Models.User(registration.Username, registration.Email, registration.Timezone, registration.Locale, true);

            var userEntity = _mapper.Map<UserEntity>(_user);
            userEntity.HashedPassword = HashPassword(_user, registration.Password);
            await _storage.CreateAsync(userEntity);
            jsonWebToken = GenerateJsonWebToken(new JwtUserClaimsDto(userEntity.Id.ToString()));
            NotificationDto notification = new NotificationDto(userEntity.Id);
            await _notifier.SendWelcomeNotificationAsync(notification);
            return jsonWebToken;
        }

        public async Task ChangePassword(string userId, ChangePasswordDto changePassword)
        {
            if (changePassword.NewPassword != changePassword.ConfirmedNewPassword)
            {
                throw new AuthenticationException(ExceptionMessage.NonMatchingPasswords);
            }

            PasswordVerificationResult verificationResult;
            UserEntity user = await _storage.FindAsync(u => u.Id == Guid.Parse(userId));
            _user = new Common.Models.User(user.Username, user.Email, user.Timezone, user.Locale, true);
            verificationResult = ValidatePassword(_user, user.HashedPassword, changePassword.OldPassword);

            switch (verificationResult)
            {
                case PasswordVerificationResult.Success:
                    break;
                case PasswordVerificationResult.Failed:
                    throw new AuthenticationException(ExceptionMessage.OldPasswordIncorrect);
                case PasswordVerificationResult.SuccessRehashNeeded:
                    break;
            }

            _user = new Common.Models.User(user.Username, user.Email, user.Timezone, user.Locale, true);
            user.HashedPassword = HashPassword(_user, changePassword.NewPassword);
            var updatedUser = await _storage.UpdateAsync(user);
            return;
        }

        public async Task ResetPasswordRequest(ResetPasswordRequestDto resetPasswordRequest)
        {
            var user = await _storage.FindAsync(m => m.Email == resetPasswordRequest.Email);
            if (user == null)
            {
                return;
            }

            user.ResetPasswordToken = TokenHelper.GenerateToken().Replace("/", "");
            user.ResetPasswordTokenExpiresAt = DateTimeOffset.Now.AddMinutes(30);
            await _storage.UpdateAsync(user);
            var notification = new NotificationDto(user.Id);
            await _notifier.SendPasswordResetNotificationAsync(notification);
        }

        public async Task ResetPassword(ResetPasswordDto resetPassword)
        {
            var user = await _storage.FindAsync(m => m.ResetPasswordToken == resetPassword.ValidationToken);
            if (user == null)
            {
                throw new AuthenticationException(ExceptionMessage.InvalidPasswordResetToken);
            }

            if(DateTimeOffset.Compare(DateTimeOffset.UtcNow, user.ResetPasswordTokenExpiresAt) > 0)
            {
                throw new AuthenticationException(ExceptionMessage.PasswordResetTokenExpired);
            }

            if (resetPassword.NewPassword != resetPassword.ConfirmNewPassword)
            {
                throw new AuthenticationException(ExceptionMessage.NonMatchingPasswords);
            }

            _user = new Common.Models.User(user.Username, user.Email, user.Timezone, user.Locale, true);
            user.HashedPassword = HashPassword(_user, resetPassword.NewPassword);
            // invalidate token after initial use
            user.ResetPasswordTokenExpiresAt = DateTimeOffset.MinValue;
            var updatedUser = await _storage.UpdateAsync(user);
            return;
        }

        private PasswordVerificationResult ValidatePassword(Common.Models.User user, string hashedPassword, string providedPassword)
        {
            return _passwordHasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
        }

        private string HashPassword(Common.Models.User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        public JsonWebTokenDto GenerateJsonWebToken(object jwtTokenData)
        {
            IdentityOptions _options = new IdentityOptions();

            var claims = new[]
            {
                new Claim(_options.ClaimsIdentity.UserIdClaimType, jwtTokenData.ToString()),
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