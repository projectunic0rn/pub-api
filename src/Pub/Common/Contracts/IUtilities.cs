using System.Threading.Tasks;
using System.Collections.Generic;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IUtilities
    {
        Task<ValidationDto> ValidateUsernameAsync(string username);
        Task<List<ProjectTypeDto>> GetProjectTypesAsync();
    }
}
