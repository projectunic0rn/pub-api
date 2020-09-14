using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.DTOs;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PubJobs.DTOs;
using PubJobs.MessageHandlers;

namespace PubJobs.BackgroundServices
{
    public class MessageListener : BackgroundService
    {
        private readonly string _serviceBusConnectionString;
        private readonly string _serviceBusQueueName;
        private IQueueClient _queueClient;
        private readonly ILogger _logger;
        private readonly CollaboratorSuggestionsHandler _collaboratorSuggestionsHandler;

        public MessageListener(ILogger<MessageListener> logger, IConfiguration configuration)
        {
            _serviceBusConnectionString = configuration["ServiceBusConnectionString"];
            _serviceBusQueueName = configuration["PubJobsQueueName"];
            _collaboratorSuggestionsHandler = new CollaboratorSuggestionsHandler();
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
        private async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {
            try
            {
                string messageBody = Encoding.UTF8.GetString(message.Body);

                switch (message.Label)
                {
                    case "compute_project_collaborator_suggestions":
                        var project = JsonConvert.DeserializeObject<ProjectDto>(messageBody);
                        await _collaboratorSuggestionsHandler.ComputeProjectCollaboratorSuggestions(project);
                        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);
                        break;
                    case "compute_developer_collaborator_suggestions":
                        var developerResourceId = JsonConvert.DeserializeObject<ResourceDto>(messageBody);
                        await _collaboratorSuggestionsHandler.ComputeDeveloperCollaboratorSuggestions(developerResourceId.Id);
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