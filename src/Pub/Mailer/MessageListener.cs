using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using Newtonsoft.Json;
using Mailer.DTOs;
using Microsoft.Extensions.Logging;
using Mailer.Contracts;
using Mailer.MailerImplementation;

namespace Mailer
{
    public class MessageListener : IHostedService
    {
        private readonly ILogger _logger;
        static IQueueClient _queueClient;
        private readonly IMailer _mailer;

        public MessageListener(ILogger<MessageListener> logger)
        {
            _logger = logger;
            _mailer = new SendGridMailer();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _queueClient = new QueueClient(AppSettings.ServiceBusConnectionString, AppSettings.ServiceBusQueueName);
            RegisterOnMessageHandlerAndReceiveMessages();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return _queueClient.CloseAsync();
        }

        private void RegisterOnMessageHandlerAndReceiveMessages()
        {
            // Configure the message handler options in terms of exception handling, number of concurrent messages to deliver, etc.
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                // Maximum number of concurrent calls to the callback ProcessMessagesAsync(), set to 1 for simplicity.
                // Set it according to how many messages the application wants to process in parallel.
                MaxConcurrentCalls = 1,

                // Indicates whether the message pump should automatically complete the messages after returning from user callback.
                // False below indicates the complete operation is handled by the user callback as in ProcessMessagesAsync().
                AutoComplete = false
            };

            // Register the function that processes messages.
            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
            // queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            try
            {
                // Deserialize message, send mail via smtp client, and complete message
                string messageBody = Encoding.UTF8.GetString(message.Body);
                EmailMessage emailMessage = JsonConvert.DeserializeObject<EmailMessage>(messageBody);
                await _mailer.SendMailAsync(emailMessage);
                await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                _logger.LogInformation($"Processed message: SequenceNumber:{message.SystemProperties.SequenceNumber}");
            }
            catch (Exception ex)
            {
                // failed to process message, mark as Abandoned
                _logger.LogError(ex, $"Error processing message: SequenceNumber:{message.SystemProperties.SequenceNumber}");
                await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
            }
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            ExceptionReceivedContext context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            _logger.LogError(exceptionReceivedEventArgs.Exception, $"Message handler encountered an exceptions. Endpoint: {context.Endpoint}, Entity Path: {context.EntityPath}, Executing Action: {context.Action}.");
            return Task.CompletedTask;
        }
    }
}