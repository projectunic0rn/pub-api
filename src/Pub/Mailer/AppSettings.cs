using System;
using Mailer.Contracts;

namespace Mailer
{
    public static class AppSettings
    {
        public static string ServiceBusConnectionString { get; set; } = Environment.GetEnvironmentVariable("ServiceBusConnectionString", EnvironmentVariableTarget.Process);
        public static string ServiceBusQueueName { get; set; } = Environment.GetEnvironmentVariable("ServiceBusQueueName", EnvironmentVariableTarget.Process);
        public static string SendGridApiKey { get; set; } = Environment.GetEnvironmentVariable("SendGridApiKey", EnvironmentVariableTarget.Process);
        public static IEmailConfiguration EmailConfiguration { get; set; }

    }
}