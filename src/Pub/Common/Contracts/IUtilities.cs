using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IUtilities
    {
        Task<ValidationDto> ValidateUsernameAsync(string username);
    }
}
