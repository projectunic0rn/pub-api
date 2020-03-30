using System;
using Common.Contracts;

namespace Common.AppSettings
{
    public class Settings
    {
        // API
        public string ApiV1 { get; } = "v1";
        public string ApiName { get; } = "Pub";
        public string Env { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
        public string JwtAudience { get; set; } = Environment.GetEnvironmentVariable("JwtAudience", EnvironmentVariableTarget.Process);
        public string JwtIssuer { get; set; } = Environment.GetEnvironmentVariable("JwtIssuer", EnvironmentVariableTarget.Process);
        public string JwtSecretKey { get; set; } = Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.Process);
        public string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);
        public IEmailConfiguration EmailConfiguration { get; set; }
        public string FeedbackRecipients { get; set; } = Environment.GetEnvironmentVariable("FeedbackRecipients", EnvironmentVariableTarget.Process);
        public string ApiKey { get; set; } = Environment.GetEnvironmentVariable("ApiKey", EnvironmentVariableTarget.Process);

        // Communication Apps (e.g. slack, discord)
        public string AppUrl { get; set; } = Environment.GetEnvironmentVariable("AppUrl", EnvironmentVariableTarget.Process);
        public string MainUrl { get; set; } = Environment.GetEnvironmentVariable("MainUrl", EnvironmentVariableTarget.Process);
        public string SlackSigningSecret { get; set; } = Environment.GetEnvironmentVariable("SlackSigningSecret", EnvironmentVariableTarget.Process);
        public string IntroductionChannelId { get; set; } = Environment.GetEnvironmentVariable("IntroductionChannelId", EnvironmentVariableTarget.Process);
        public string SlackAuthToken { get; set; } = Environment.GetEnvironmentVariable("SlackAuthToken", EnvironmentVariableTarget.Process);
        public string GitHubOrganization { get; set; } = Environment.GetEnvironmentVariable("GitHubOrganization", EnvironmentVariableTarget.Process);
        public string GitHubAppId { get; set; } = Environment.GetEnvironmentVariable("GitHubAppId", EnvironmentVariableTarget.Process);
        public string GitHubAppInstallationId { get; set; } = Environment.GetEnvironmentVariable("GitHubAppInstallationId", EnvironmentVariableTarget.Process);
        public string GitHubAppPrivateRSAKey { get; set; } = Environment.GetEnvironmentVariable("GitHubAppPrivateRSAKey", EnvironmentVariableTarget.Process);
        public string GitHubInstallationAccessToken { get; set; } = Environment.GetEnvironmentVariable("GitHubInstallationAccessToken", EnvironmentVariableTarget.Process);
        public string PrivilegedMembers { get; set; } = Environment.GetEnvironmentVariable("PrivilegedMembers", EnvironmentVariableTarget.Process);

        // Mail Engine
        public string SendGridTemplatesApiKey { get; set; } = Environment.GetEnvironmentVariable("SendGridTemplatesApiKey", EnvironmentVariableTarget.Process);
        public string ServiceBusConnectionString { get; set; } = Environment.GetEnvironmentVariable("ServiceBusConnectionString", EnvironmentVariableTarget.Process);
        public string ServiceBusQueueName { get; set; } = Environment.GetEnvironmentVariable("ServiceBusQueueName", EnvironmentVariableTarget.Process);
        public string TableStorageConnectionString { get; set; } = Environment.GetEnvironmentVariable("TableStorageConnectionString", EnvironmentVariableTarget.Process);
        public string StorageTableName { get; set; } = Environment.GetEnvironmentVariable("StorageTableName", EnvironmentVariableTarget.Process);
        public string MailTrackingTableName { get; set; } = Environment.GetEnvironmentVariable("StorageTableName", EnvironmentVariableTarget.Process);

        // Pub Jobs
        public string PubApiEndpoint { get; set; } = Environment.GetEnvironmentVariable("PubApiEndpoint", EnvironmentVariableTarget.Process);
    }
}
