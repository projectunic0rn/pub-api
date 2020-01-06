using System;
using System.Threading;
using System.Threading.Tasks;
using MailEngine.Utility;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MailEngine.Config;
using Common.DTOs.MailDTOs;
using Common.Contracts;

namespace MailEngine.Mails.ScheduledMails
{
    public class ProjectLaunchShowcase : BackgroundService
    {
        private readonly ILogger<ProjectLaunchShowcase> _logger;
        private MailConfigDto _mailConfigDto;
        private readonly MailConfig _mailConfig;
        private readonly string _mailName = "ProjectLaunchShowcase";

        public ProjectLaunchShowcase(ILogger<ProjectLaunchShowcase> logger, IMailConfigStorage mailConfigStorage)
        {
            _logger = logger;
            _mailConfig = new MailConfig(mailConfigStorage);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _mailConfigDto = await _mailConfig.GetConfig(_mailName);

            while (!stoppingToken.IsCancellationRequested)
            {
                if (BackgroundTask.ShouldStart(_mailConfigDto.NextSend))
                {
                    _mailConfigDto = await _mailConfig.GetConfig(_mailName);
                    _logger.LogInformation($"Preparing {_mailConfigDto.Name} mail.");
                    await _mailConfig.UpdateConfigNextSend(_mailName);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}