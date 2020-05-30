using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IAuthentication
    {
        Task<JsonWebTokenDto> LoginUserAsync(LoginDto login);
        Task<JsonWebTokenDto> RegisterUserAsync(RegistrationDto register);
        Task ChangePassword(string userId, ChangePasswordDto changePassword);
        Task ResetPasswordRequest(ResetPasswordRequestDto resetPasswordRequest);
        Task ResetPassword(ResetPasswordDto resetPassword);

    }
}
