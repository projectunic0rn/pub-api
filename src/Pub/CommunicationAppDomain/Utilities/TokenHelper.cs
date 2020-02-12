using System;
using System.Security.Cryptography;

namespace CommunicationAppDomain.Utilities
{
    public static class TokenHelper
    {
        public static string GenerateToken()
        {
            byte[] randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public static string GenerateWebSafeToken()
        {
            byte[] randomNumber = new byte[32];
            string token = string.Empty;
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                token = Convert.ToBase64String(randomNumber);
            }

            token = token.Replace("/", "");
            token = Uri.EscapeDataString(token);
            return token;
        }
    }
}
