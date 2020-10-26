using System;
using Common.Contracts;

namespace Common.AppSettings
{
    // AppSettings will be removed
    // Start using Settings.cs
    public static class AppSettings
    {
        // API
        public static string ApiV1 { get; } = "v1.0.42";
        public static string ApiName { get; } = "Pub";
        public static string Env { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
        public static string JwtAudience { get; set; } = Environment.GetEnvironmentVariable("JwtAudience", EnvironmentVariableTarget.Process);
        public static string JwtIssuer { get; set; } = Environment.GetEnvironmentVariable("JwtIssuer", EnvironmentVariableTarget.Process);
        public static string JwtSecretKey { get; set; } = Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.Process);
        public static string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);
        public static IEmailConfiguration EmailConfiguration { get; set; }
        public static string FeedbackRecipients { get; set; } = Environment.GetEnvironmentVariable("FeedbackRecipients", EnvironmentVariableTarget.Process);
        public static string ApiKey { get; set; } = Environment.GetEnvironmentVariable("ApiKey", EnvironmentVariableTarget.Process);
        public static string PubSlackAppQueueName { get; set; } = Environment.GetEnvironmentVariable("PubSlackAppQueueName", EnvironmentVariableTarget.Process);
        public static string PubJobsQueueName { get; set; } = Environment.GetEnvironmentVariable("PubJobsQueueName", EnvironmentVariableTarget.Process);

        // Communication Apps (e.g. slack, discord)
        public static string MainUrl { get; set; } = Environment.GetEnvironmentVariable("MainUrl", EnvironmentVariableTarget.Process);
        public static string SlackSigningSecret { get; set; } = Environment.GetEnvironmentVariable("SlackSigningSecret", EnvironmentVariableTarget.Process);
        public static string IntroductionChannelId { get; set; } = Environment.GetEnvironmentVariable("IntroductionChannelId", EnvironmentVariableTarget.Process);
        public static string PrivateIntroChannelId { get; set; } = Environment.GetEnvironmentVariable("PrivateIntroChannelId", EnvironmentVariableTarget.Process);
        public static string PrivateRegistrationChannelId { get; set; } = Environment.GetEnvironmentVariable("PrivateRegistrationChannelId", EnvironmentVariableTarget.Process);
        public static string PrivateProjectsChannelId { get; set; } = Environment.GetEnvironmentVariable("PrivateProjectsChannelId", EnvironmentVariableTarget.Process);
        public static string PrivateFeedbackChannelId { get; set; } = Environment.GetEnvironmentVariable("PrivateFeedbackChannelId", EnvironmentVariableTarget.Process);
        public static string ProjectIdeasChannelId { get; set; } = Environment.GetEnvironmentVariable("ProjectIdeasChannelId", EnvironmentVariableTarget.Process);

        public static string SlackAuthToken { get; set; } = Environment.GetEnvironmentVariable("SlackAuthToken", EnvironmentVariableTarget.Process);
        public static string GitHubOrganization { get; set; } = Environment.GetEnvironmentVariable("GitHubOrganization", EnvironmentVariableTarget.Process);
        public static string GitHubAppId { get; set; } = Environment.GetEnvironmentVariable("GitHubAppId", EnvironmentVariableTarget.Process);
        public static string GitHubAppInstallationId { get; set; } = Environment.GetEnvironmentVariable("GitHubAppInstallationId", EnvironmentVariableTarget.Process);
        public static string GitHubAppPrivateRSAKey { get; set; } = Environment.GetEnvironmentVariable("GitHubAppPrivateRSAKey", EnvironmentVariableTarget.Process);
        public static string GitHubInstallationAccessToken { get; set; } = Environment.GetEnvironmentVariable("GitHubInstallationAccessToken", EnvironmentVariableTarget.Process);
        public static string PrivilegedMembers { get; set; } = Environment.GetEnvironmentVariable("PrivilegedMembers", EnvironmentVariableTarget.Process);

        // Mail Engine
        public static string SendGridTemplatesApiKey { get; set; } = Environment.GetEnvironmentVariable("SendGridTemplatesApiKey", EnvironmentVariableTarget.Process);
        public static string ServiceBusConnectionString { get; set; } = Environment.GetEnvironmentVariable("ServiceBusConnectionString", EnvironmentVariableTarget.Process);
        public static string ServiceBusQueueName { get; set; } = Environment.GetEnvironmentVariable("ServiceBusQueueName", EnvironmentVariableTarget.Process);
        public static string TableStorageConnectionString { get; set; } = Environment.GetEnvironmentVariable("TableStorageConnectionString", EnvironmentVariableTarget.Process);
        public static string StorageTableName { get; set; } = Environment.GetEnvironmentVariable("StorageTableName", EnvironmentVariableTarget.Process);

        //
    }
}
