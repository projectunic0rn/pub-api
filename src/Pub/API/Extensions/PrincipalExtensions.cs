using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using Newtonsoft.Json;
using Common.DTOs;
namespace API.Extensions
{
    public static class PrincipalExtensions
    {
        static PrincipalExtensions()
        {
        }

        public static string GetUserId(this IIdentity identity)
        {
            string userId = string.Empty;
            var claimsIdentity = identity as ClaimsIdentity;
            var claims = claimsIdentity.Claims;
            foreach(Claim claim in claims)
            {
                if(claim.Type == ClaimTypes.UserData)
                {
                    var userClaims = JsonConvert.DeserializeObject<JwtUserClaimsDto>(claim.Value);
                    userId = userClaims.Id;
                }
            }

            return userId;
        }
    }
}