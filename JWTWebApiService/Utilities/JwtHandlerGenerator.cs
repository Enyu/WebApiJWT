using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JwtAuthForWebAPI;

namespace JWTWebApiService.Utilities
{
    public static class JwtHandlerGenerator
    {
        public static JwtAuthenticationMessageHandler GenerateJwtHandler()
        {
            var builder = new SecurityTokenBuilder();
            return new JwtAuthenticationMessageHandler
            {
                AllowedAudience = "http://www.enyu.com",
                AllowedAudiences = new[] { "http://www.enyuyu.com" },
                Issuer = "DMN",
                SigningToken = builder.CreateFromCertificate("CN=JwtAuthForWebAPI enyu"),
            };
        }
    }
}