using System;

namespace Common.AppSettings
{
    public static class AppSettings
    {
        public static string ApiV1 { get; } = "v1";
        public static string ApiName { get; } = "Pub";
        public static string JwtAudience { get; set; } = Environment.GetEnvironmentVariable("JwtAudience", EnvironmentVariableTarget.Process);
        public static string JwtIssuer { get; set; } = Environment.GetEnvironmentVariable("JwtIssuer", EnvironmentVariableTarget.Process);
        public static string JwtSecretKey { get; set; } = Environment.GetEnvironmentVariable("JwtSecretKey", EnvironmentVariableTarget.Process);
        public static string ConnectionString { get; set; } = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);
    }
}
