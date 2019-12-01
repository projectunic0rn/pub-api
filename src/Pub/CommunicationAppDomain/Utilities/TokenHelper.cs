using System;
using System.Security.Cryptography;

namespace CommunicationAppDomain.Utilities
{
    public static class TokenHelper
    {
        public static string GenerateToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
