using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs.MailDTOs;

namespace MailEngine.Config
{
    // Summary:
    //     MailConfig reads and caches the settings
    //     for each transactional or scheduled email 
    //     sent
    public class MailConfig
    {
        private readonly IMailConfigStorage _mailConfigStorage;
        public MailConfig(IMailConfigStorage mailConfigStorage)
        {
            _mailConfigStorage = mailConfigStorage;
            InitializeConfiguration();
        }
        private Dictionary<string, MailConfigDto> Config { get; set; }

        // Summary:
        //     GetConfig loads mail configuration from storage
        //     if found, otherwise we write it to storage and
        //     store it in memory.
        // Parameters:
        //   mailName:
        //     The identifier to use when loading the mail configuration.
        //
        public async Task<MailConfigDto> GetConfig(string mailName)
        {
            MailConfigDto mailConfigDto = await _mailConfigStorage.LoadConfig(mailName);
            if (mailConfigDto == null)
            {
                MailConfigDto cachedMailConfigDto = Config[mailName];
                cachedMailConfigDto.LastSend = DateTimeOffset.UtcNow;
                cachedMailConfigDto.NextSend = DateTimeOffset.UtcNow;
                mailConfigDto = await _mailConfigStorage.InsertOrUpdateConfig(cachedMailConfigDto);
                Config[mailName] = mailConfigDto;
            }
            else
            {
                Config[mailName] = mailConfigDto;
            }
            return Config[mailName];
        }

        // Summary:
        //     UpdateConfigNextSend increments the NextSend property 
        //     by IntervalSeconds and persists the new mail config to 
        //     storage.
        // Parameters:
        //   mailName:
        //     The identifier to use when loading the mail configuration.
        //
        public async Task UpdateConfigNextSend(string mailName)
        {
            MailConfigDto mailConfigDto = Config[mailName];
            mailConfigDto.LastSend = DateTimeOffset.UtcNow;
            mailConfigDto.NextSend = DateTimeOffset.UtcNow.AddSeconds(mailConfigDto.IntervalSeconds);
            mailConfigDto = await _mailConfigStorage.InsertOrUpdateConfig(mailConfigDto);
            Config[mailName] = mailConfigDto;
            return;
        }
        
        // Summary:
        //     InitializeConfiguration contains the initial properties
        //     for each transactional and scheduled email. These are
        //     used to populate the storage if they are not already stored.
        //
        private void InitializeConfiguration()
        {
            Config = new Dictionary<string, MailConfigDto>()
            {
                {
                    "ProjectRecommendations",
                    new MailConfigDto {
                        Name = "ProjectRecommendations",
                        Type = MailType.Scheduled,
                        TemplateId = "d-cd7be025aef24c6cba1724359ff333c5",
                        IntervalSeconds = 2592000,
                        LastSend = null,
                        NextSend = null
                     }
                },
                {
                    "ProjectLaunchShowcase",
                    new MailConfigDto {
                        Name = "ProjectLaunchShowcase",
                        Type = MailType.Scheduled,
                        TemplateId = "d-e1944eb05d6a47d388ea51efca5f7847",
                        IntervalSeconds = 2592000,
                        LastSend = null,
                        NextSend = null
                     }
                },
                // IntervalSeconds not applicable for Transaction Mail
                {
                    "WelcomeMessage",
                    new MailConfigDto {
                        Name = "WelcomeMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-532a6f1c50d44cc5861d4754cb5c591b",
                        IntervalSeconds = 0,
                        LastSend = null,
                        NextSend = null
                     }
                },
                {
                    "FeedbackMessage",
                    new MailConfigDto {
                        Name = "FeedbackMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-d6967b05bf5c4ad584b602301ef557fd",
                        IntervalSeconds = 0,
                        LastSend = null,
                        NextSend = null
                     }
                },
            };
        }
    }
}