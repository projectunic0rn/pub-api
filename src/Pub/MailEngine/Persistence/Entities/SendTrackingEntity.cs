using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace MailEngine.Persistence.Entities
{
    public class SendTrackingEntity : TableEntity
    {
        public SendTrackingEntity()
        {
        }

        public SendTrackingEntity(string mailIdentifier, string notifierId)
        {
            PartitionKey = mailIdentifier;
            RowKey = notifierId;
        }

        public int MaxSends { get; set; }
        public int TotalSends { get; set; }
        public long SendIntervalSeconds { get; set; }
        public DateTimeOffset LastSend { get; set; }
    }
}
