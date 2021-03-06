using System;
using System.Security.Cryptography;

namespace Domain.Helpers
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
    }
}
