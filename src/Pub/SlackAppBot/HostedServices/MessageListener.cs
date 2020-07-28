using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs.SlackAppDTOs;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using CommunicationAppDomain.Handlers;
using Common.DTOs;

namespace SlackAppBot.HostedServices
{
    public class MessageListener: BackgroundService
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _serviceBusQueueName;
        private IQueueClient _queueClient;
        private readonly IChatAppCommandHandler _commandHandler;
        private readonly IChatAppEventHandler _eventHandler;
        private readonly ApiEventHandler _apiEventHandler;
        private readonly ILogger _logger;

        public MessageListener(ILogger<MessageListener> logger, IConfiguration configuration, IChatAppCommandHandler chatAppCommandHandler, IChatAppEventHandler chatAppEventHandler)
        {
            _serviceBusConnectionString = configuration["ServiceBusConnectionString"];
            _serviceBusQueueName = configuration["ServiceBusQueueName"];
            _eventHandler = chatAppEventHandler;
            _commandHandler = chatAppCommandHandler;
            _commandHandler = chatAppCommandHandler;
            _apiEventHandler = new ApiEventHandler();
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _queueClient = new QueueClient(_serviceBusConnectionString, _serviceBusQueueName);
            RegisterOnMessageHandlerAndReceiveMessages();
            return Task.CompletedTask;
        }

        private void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        /// <summary>
        /// Message to process incoming messages from service bus queue.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task ProcessMessagesAsync(Microsoft.Azure.ServiceBus.Message message, CancellationToken token)
        {
            try
            {
                string messageBody = Encoding.UTF8.GetString(message.Body);

                switch (message.Label)
                {
                    case "command":
                        SlackCommandDto slackCommandDto = JsonConvert.DeserializeObject<SlackCommandDto>(messageBody);
                        await _commandHandler.ProcessCommand(slackCommandDto);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                        break;
                    case "event":
                        SlackEventDto slackEventDto = JsonConvert.DeserializeObject<SlackEventDto>(messageBody);
                        await _eventHandler.ProcessEvent(slackEventDto);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                        break;
                    case "projectpost":
                        ProjectDto project = JsonConvert.DeserializeObject<ProjectDto>(messageBody);
                        await _apiEventHandler.ProcessProjectPost(project);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                        break;
                    case "registration":
                        RegistrationDto registration = JsonConvert.DeserializeObject<RegistrationDto>(messageBody);
                        await _apiEventHandler.ProcessRegistration(registration);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                        break;
                    case "feedback":
                        FeedbackDto feedback = JsonConvert.DeserializeObject<FeedbackDto>(messageBody);
                        await _apiEventHandler.ProcessFeedback(feedback);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                        break;
                    default:
                        _logger.LogWarning($"No label associated with message:{message.SystemProperties.SequenceNumber}");
                        break;
                };

                _logger.LogInformation($"Processed message: SequenceNumber:{message.SystemProperties.SequenceNumber}");
            }
            catch (Exception ex)
            {
                // failed to process message, mark as Abandoned
                _logger.LogError(ex, $"Error processing message: SequenceNumber:{message.SystemProperties.SequenceNumber}");
                await _queueClient.DeadLetterAsync(message.SystemProperties.LockToken);
            }
        }

        /// <summary>
        /// Handler to examine the exceptions on the message pump
        /// </summary>
        /// <param name="exceptionReceivedEventArgs"></param>
        /// <returns></returns>
        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            _logger.LogError($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            ExceptionReceivedContext context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            _logger.LogError(exceptionReceivedEventArgs.Exception, $"Message handler encountered an exceptions. Endpoint: {context.Endpoint}, Entity Path: {context.EntityPath}, Executing Action: {context.Action}.");
            return Task.CompletedTask;
        }
    }
}
