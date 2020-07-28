using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Messaging
{
    public class MessageQueue : IMessageQueue
    {
        private IQueueClient _queueClient;
        private string _serviceBusConnectionString;
        private string _serviceBusQueueName;
        private int _serviceBusMessageLimitByteCount;
        private readonly ILogger _logger;

        public MessageQueue(string serviceBusConnectionString, string serviceBusQueueName, ILogger<MessageQueue> logger)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
            _serviceBusQueueName = serviceBusQueueName;
            // Service Bus limits standard tier to message size
            // of 256KB more info here https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-quotas
            _serviceBusMessageLimitByteCount = 256000;
            _logger = logger;
        }

        /// <summary>
        /// Send a single message to the Azure service bus message queue.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageObject">Object set as message body.</param>
        /// <param name="messageLabel">A label associated with the message used by the receiving application for app specific processing</param>
        /// <param name="enqueueTime">Message enqueue time</param>
        /// <param name="queueName">Override default queue name</param>
        /// <returns></returns>
        public async Task SendMessageAsync<T>(T messageObject, string messageLabel = null, DateTime? enqueueTime = null, string queueName = null)
        {
            int totalMessageCount = 1;
            string name = queueName == null ? _serviceBusQueueName : queueName;
            _queueClient = new QueueClient(_serviceBusConnectionString, name);
            string serializedMessage = JsonConvert.SerializeObject(messageObject);
            byte[] messageContent = Encoding.UTF8.GetBytes(serializedMessage);
            Message message = new Message(messageContent)
            {
                Label = messageLabel
            };
            message.ScheduledEnqueueTimeUtc = (DateTime)(enqueueTime == null ? DateTime.UtcNow : enqueueTime);
            await _queueClient.SendAsync(message);
            await _queueClient.CloseAsync();
            _logger.LogInformation($"Queued {totalMessageCount} of {totalMessageCount} message(s)");
            return;
        }

        /// <summary>
        /// Send multiple messages to the Azure service bus message queue.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageObject">Object set as message body.</param>
        /// <param name="messageLabel">A label associated with the messages used by the receiving application for app specific processing</param>
        /// <param name="enqueueTime">Message enqueue time</param>
        /// <param name="queueName">Override default queue name</param>
        /// <returns></returns>
        public async Task SendMessagesAsync<T>(List<T> messageObjects, string messageLabel = null, DateTime? enqueueTime = null, string queueName = null)
        {
            string name = queueName == null ? _serviceBusQueueName : queueName;
            _queueClient = new QueueClient(_serviceBusConnectionString, name);
            List<Message> messages = new List<Message>();
            long totalMessagesByteCount = 0;
            int totalMessageCount = messageObjects.Count;
            int messagesProcessed = 0;
            foreach (T messageObject in messageObjects)
            {
                string serializedMessage = JsonConvert.SerializeObject(messageObject);
                byte[] messageContent = Encoding.UTF8.GetBytes(serializedMessage);
                Message message = new Message(messageContent)
                {
                    Label = messageLabel
                };
                message.ScheduledEnqueueTimeUtc = (DateTime)(enqueueTime == null ? DateTime.UtcNow : enqueueTime);
                totalMessagesByteCount += message.Size;

                if (totalMessagesByteCount >= _serviceBusMessageLimitByteCount)
                {
                    // Message exceeds byte count limit so
                    // send these messages and start new message
                    // list.
                    await _queueClient.SendAsync(messages);
                    messagesProcessed += messages.Count;
                    _logger.LogInformation($"Queued {messagesProcessed} of {totalMessageCount} message(s)");
                    messages = new List<Message>();
                    totalMessagesByteCount = message.Size;
                }

                messages.Add(message);
            }

            await _queueClient.SendAsync(messages);
            await _queueClient.CloseAsync();
            messagesProcessed += messages.Count;
            _logger.LogInformation($"Queued {messagesProcessed} of {totalMessageCount} message(s)");
            return;
        }
    }
}