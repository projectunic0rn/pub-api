using System;
using Microsoft.AspNetCore.Authentication;

namespace API.AuthScheme
{
    public class ApiKeyAuthenticationOptions: AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "APIKey";
        public string Scheme => DefaultScheme;
        public string AuthenticationType = DefaultScheme;
    }
}
