using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Common.DTOs.MailDTOs;
using Common.Contracts;

namespace Infrastructure.Persistence.TableStorage
{
    // TODO: Deprecated, please use Storage.cs in same directory
    // services should own their entity and use Storage.cs in 
    // Infrastructure to persists
    public class MailConfigStorage : IMailConfigStorage
    {
        private readonly CloudTable _mailConfigTable;
        private readonly string _mailConfigPartitionKey = "mailconfig";
        public MailConfigStorage(string tableStorageConnectionString, string storageTableName)
        {
            CloudStorageAccount _account = CloudStorageAccount.Parse(tableStorageConnectionString);
            CloudTableClient _tableStorageClient = _account.CreateCloudTableClient();
            _mailConfigTable = _tableStorageClient.GetTableReference(storageTableName);
            _mailConfigTable.CreateIfNotExistsAsync().GetAwaiter().GetResult();
        }

        public async Task<MailConfigDto> LoadConfig(string mailName)
        {
            TableOperation operation = TableOperation.Retrieve<MailConfigEntity>(_mailConfigPartitionKey, mailName);
            TableResult result = await _mailConfigTable.ExecuteAsync(operation);
            MailConfigEntity mailConfig = result.Result as MailConfigEntity;
            if (mailConfig != null)
            {
                MailConfigDto mailConfigDto = MapToMailConfigDto(mailConfig);
                return mailConfigDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<MailConfigDto> InsertOrUpdateConfig(MailConfigDto mailConfigDto)
        {
            MailConfigEntity mailConfigEntity = MapToMailEntity(mailConfigDto);
            TableOperation operation = TableOperation.InsertOrMerge(mailConfigEntity);
            TableResult result = await _mailConfigTable.ExecuteAsync(operation);
            MailConfigDto mailConfig = MapToMailConfigDto(result.Result as MailConfigEntity);
            return mailConfig;
        }

        private MailConfigDto MapToMailConfigDto(MailConfigEntity mailConfig)
        {
            MailConfigDto mailConfigDto = new MailConfigDto(mailConfig.Name, mailConfig.Type, mailConfig.TemplateId, mailConfig.IntervalSeconds, mailConfig.LastSend.Value, mailConfig.NextSend.Value);
            return mailConfigDto;
        }

        private MailConfigEntity MapToMailEntity(MailConfigDto mailConfig)
        {
            MailConfigEntity mailConfigEntity = new MailConfigEntity(mailConfig.Name);
            mailConfigEntity.Name = mailConfig.Name;
            mailConfigEntity.Type = mailConfig.Type;
            mailConfigEntity.TemplateId = mailConfig.TemplateId;
            mailConfigEntity.IntervalSeconds = mailConfig.IntervalSeconds;
            mailConfigEntity.LastSend = mailConfig.LastSend;
            mailConfigEntity.NextSend = mailConfig.NextSend;
            return mailConfigEntity;
        }
    }
}