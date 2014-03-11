using System;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using JWTWebApiService.Entities;
using NUnit.Framework;

namespace JWTWebApiService.Tests
{
    [TestFixture]
    public class JwtIntegrationTests
    {
        //Before you run the integration tests
        //1. Must set up local server in IIS.
        //2. open vs Developer Command Prompt
        //3. makecert -r -n "CN=your CN" -sky signature -ss My -sr localmachine
        //4. certmgr /add /c /n "JwtAuthForWebAPI Example" /s /r localmachine My /s /r localmachine root
        public readonly Uri ApiUrl = new Uri("http://localhost:5560");
        public const string CertificateName = "CN=JwtAuthForWebAPI enyu";

        [Test]
        public void should_fail_with_401_when_client_without_token()
        {
            var client = new HttpClient { BaseAddress = ApiUrl };
            var response = client.GetAsync("api/apples/1").Result;

            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Test]
        public void should_pass_when_client_with_token()
        {
            var client = new HttpClient { BaseAddress = ApiUrl };
            AddAuthHeader(client);
            var response = client.GetAsync("api/apples/1").Result;

            response.StatusCode.Should().Be(HttpStatusCode.Found);
            var apple = response.Content.ReadAsAsync<Apple>();
            apple.Id.Should().Be(1);
        }

        private static void AddAuthHeader(HttpClient client, string audience = "http://www.enyu.com")
        {
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            var signingCert = store.Certificates
                .Cast<X509Certificate2>()
                .FirstOrDefault(certificate => certificate.Subject == CertificateName);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                TokenIssuerName = "DMN",
                AppliesToAddress = audience,
                SigningCredentials = new X509SigningCredentials(signingCert)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenString);
        }
    }
}
