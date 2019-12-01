using System;
using System.Collections.Generic;
using Common.Contracts;

namespace Common.AppSettings
{
    public static class AppSettings
    {
        // API
        public static string ApiV1 { get; } = "v1";
        public static string ApiName { get; } = "Pub";
        public static string Env { get; set; } = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", EnvironmentVariableTarget.Process);
        public static string JwtAudience { get; set; } = Environment.GetEnvironmentVariable("JwtAudience", EnvironmentVariableTarget.Process);
        public static string JwtIssuer { get; set; } = Environment.GetEnvironmentVariable("JwtIssuer", EnvironmentVariableTarget.Process);
        public static string JwtSecretKey { get; set; } = Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.Process);
        public static string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);
        public static IEmailConfiguration EmailConfiguration { get; set; }
        public static string FeedbackRecipients { get; set; } = Environment.GetEnvironmentVariable("FeedbackRecipients", EnvironmentVariableTarget.Process);
        public static string MailerFromAddress { get; set; } = Environment.GetEnvironmentVariable("MailerFromAddress", EnvironmentVariableTarget.Process);

        // Communication Apps (e.g. slack, discord)
        public static string AppUrl { get; set; } = Environment.GetEnvironmentVariable("AppUrl", EnvironmentVariableTarget.Process);
        public static string MainUrl { get; set; } = Environment.GetEnvironmentVariable("MainUrl", EnvironmentVariableTarget.Process);
        public static string SlackSigningSecret { get; set; } = Environment.GetEnvironmentVariable("SlackSigningSecret", EnvironmentVariableTarget.Process);
        public static string SlackAuthToken { get; set; } = Environment.GetEnvironmentVariable("SlackAuthToken", EnvironmentVariableTarget.Process);
        public static string GitHubOrganization { get; set; } = Environment.GetEnvironmentVariable("GitHubOrganization", EnvironmentVariableTarget.Process);
        public static string GitHubAppId { get; set; } = Environment.GetEnvironmentVariable("GitHubAppId", EnvironmentVariableTarget.Process);
        public static string GitHubAppInstallationId { get; set; } = Environment.GetEnvironmentVariable("GitHubAppInstallationId", EnvironmentVariableTarget.Process);
        public static string GitHubAppPrivateRSAKey { get; set; } = Environment.GetEnvironmentVariable("GitHubAppPrivateRSAKey", EnvironmentVariableTarget.Process);
        public static string GitHubInstallationAccessToken { get; set; } = Environment.GetEnvironmentVariable("GitHubInstallationAccessToken", EnvironmentVariableTarget.Process);
    }
}
