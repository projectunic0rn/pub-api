using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Common.Contracts;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace Infrastructure.Messaging
{
    public class MessageQueue : IMessageQueue
    {
        private IQueueClient _queueClient;
        private string _serviceBusConnectionString;
        private string _serviceBusQueueName;

        public MessageQueue(string serviceBusConnectionString, string serviceBusQueueName)
        {
            _serviceBusConnectionString = serviceBusConnectionString;
            _serviceBusQueueName = serviceBusQueueName;
        }

        public async Task SendMessageAsync<T>(T messageObject)
        {
            _queueClient = new QueueClient(_serviceBusConnectionString, _serviceBusQueueName);
            string serializedMessage = JsonConvert.SerializeObject(messageObject);
            byte[] messageContent = Encoding.UTF8.GetBytes(serializedMessage);
            Message message = new Message(messageContent);
            await _queueClient.SendAsync(message);
            await _queueClient.CloseAsync();
            return;
        }

        public async Task SendMessagesAsync<T>(List<T> messageObjects)
        {
            _queueClient = new QueueClient(_serviceBusConnectionString, _serviceBusQueueName);
            List<Message> messages = new List<Message>();
            foreach (T messageObject in messageObjects)
            {
                string serializedMessage = JsonConvert.SerializeObject(messageObject);
                byte[] messageContent = Encoding.UTF8.GetBytes(serializedMessage);
                Message message = new Message(messageContent);
                messages.Add(message);
            }
            await _queueClient.SendAsync(messages);
            await _queueClient.CloseAsync();
            return;
        }
    }
}