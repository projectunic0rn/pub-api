using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTOs.MailDTOs;

namespace Common.Contracts
{
    public interface IMailConfigStorage
    {
        Task<MailConfigDto> LoadConfig(string mailName);
        Task<MailConfigDto> InsertOrUpdateConfig(MailConfigDto mailConfig);
    }
}