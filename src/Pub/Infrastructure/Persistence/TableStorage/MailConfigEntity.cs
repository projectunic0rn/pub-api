using System;
using Common.DTOs.MailDTOs;
using Microsoft.WindowsAzure.Storage.Table;

namespace Infrastructure.Persistence.TableStorage
{
    public class MailConfigEntity: TableEntity
    {
        public MailConfigEntity()
        {
        }

        public MailConfigEntity(string mailName)
        {
            PartitionKey = "mailconfig";
            RowKey = mailName;
        }

        public string Name { get; set; }
        public MailType Type { get; set; }
        public string TemplateId { get; set; }
        public int IntervalSeconds { get; set; }
        public DateTimeOffset? LastSend { get; set; }
        public DateTimeOffset? NextSend { get; set; }
    }
}