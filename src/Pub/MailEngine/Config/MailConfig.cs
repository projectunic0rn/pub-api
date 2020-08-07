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
                cachedMailConfigDto.LastSend = cachedMailConfigDto.LastSend;
                cachedMailConfigDto.NextSend = cachedMailConfigDto.NextSend;
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
        //     If the record does not exist in the mail config storage, 
        //     the value of NextSend is used to determine when the initial
        //     mail will be sent (not applicable for transactional mails).
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
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UtcNow
                     }
                },
                {
                    "ProjectLaunchShowcase",
                    new MailConfigDto {
                        Name = "ProjectLaunchShowcase",
                        Type = MailType.Scheduled,
                        TemplateId = "d-e1944eb05d6a47d388ea51efca5f7847",
                        IntervalSeconds = 2147483647,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.MaxValue
                     }
                },
                // IntervalSeconds, LastSend, and NextSend 
                // not applicable for Transaction Mail
                {
                    "WelcomeMessage",
                    new MailConfigDto {
                        Name = "WelcomeMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-532a6f1c50d44cc5861d4754cb5c591b",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                     }
                },
                {
                    "FeedbackMessage",
                    new MailConfigDto {
                        Name = "FeedbackMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-d6967b05bf5c4ad584b602301ef557fd",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                     }
                },
                {
                    "InvalidWorkspaceInviteMessage",
                    new MailConfigDto {
                        Name = "InvalidWorkspaceInviteMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-47642e22242f4c09bf2f98b225723718",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                     }
                },
                {
                    "YouJoinedProjectMessage",
                    new MailConfigDto {
                        Name = "YouJoinedProjectMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-5c1013ca224b4f0aa00d2e1224508ed4",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                     }
                },
                {
                    "PasswordResetRequestMessage",
                    new MailConfigDto {
                        Name = "PasswordResetRequestMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-01d8c4985fca43d8bfe346185a62215f",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                     }
                },
                {
                    "ProjectPostedMessage",
                    new MailConfigDto {
                        Name = "ProjectPostedMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-376a90b290c440e98b8c6381ffd10dba",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                     }
                },
                {
                    "InitialFeedbackRequestMessage",
                    new MailConfigDto {
                        Name = "InitialFeedbackRequestMessage",
                        Type = MailType.Transactional,
                        TemplateId = "d-584dfa8b96144f2bb144d9a665843320",
                        IntervalSeconds = 0,
                        LastSend = DateTimeOffset.UnixEpoch,
                        NextSend = DateTimeOffset.UnixEpoch
                    }
                }
            };
        }
    }
}