using System;
using System.Net;
using System.Net.Http;
using FluentAssertions;
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
    }
}
