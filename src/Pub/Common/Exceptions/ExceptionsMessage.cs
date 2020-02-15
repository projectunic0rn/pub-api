namespace Common.Exceptions
{
    public static class ExceptionMessage
    {
        // Application Startup Exceptions
        public static string ApplicationMissingStartupVariables { get; } = "Application startup variable(s) missing.";

        // External service exceptions Slack API, SendGrid API, etc.
        public static string SlackServiceBadRequestScopeMissing { get; } = "Slack service bad request, missing scope.";
        public static string SlackServiceBadRequestError { get; } = "Slack service bad request, error.";
    }
}
