using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IAuthentication
    {
        Task<JsonWebTokenDto> LoginUserAsync(LoginDto login);
        Task<JsonWebTokenDto> RegisterUserAsync(RegistrationDto login);
    }
}
