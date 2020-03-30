using System;
using System.Threading.Tasks;
using Infrastructure.Persistence.TableStorage;
using MailEngine.Persistence.Entities;

namespace MailEngine.Utility
{
    /// <summary>
    /// Helper class to validate if mail should be sent.
    /// </summary>
    public class MailValidation
    {
        private readonly Storage<SendTrackingEntity> _sendingTrackingEntity;

        public MailValidation(Storage<SendTrackingEntity> sendingTrackingEntity)
        {
            _sendingTrackingEntity = sendingTrackingEntity;
        }

        public async Task<bool> IsDuplicateSend(string mailIdentifier, string notifierId)
        {
            string partitionKey = mailIdentifier;
            string rowKey = notifierId;
            var entity = await _sendingTrackingEntity.RetrieveEntity(partitionKey, rowKey);
            if(entity == null)
            {
                var persistEntity = new SendTrackingEntity()
                {
                    PartitionKey = partitionKey,
                    RowKey = rowKey,
                    MaxSends = 3,
                    TotalSends = 1,
                    SendIntervalSeconds = 604800,
                    LastSend = DateTimeOffset.UtcNow,
                };
                await _sendingTrackingEntity.InsertOrMerge(persistEntity);
                return false;
            }


            if (DateTimeOffset.Compare(DateTimeOffset.UtcNow, entity.LastSend.AddSeconds(entity.SendIntervalSeconds)) < 0)
            {
                // Next send interval has not been reached.
                return true;
            }

            if(entity.TotalSends >= entity.MaxSends)
            {
                // do not allow sending if message has met max sends
                return true;
            }

            entity.LastSend = DateTimeOffset.UtcNow;
            entity.TotalSends += 1;
            await _sendingTrackingEntity.InsertOrMerge(entity);

            return false;
        }
    }
}
