using BccCode.PubSub.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BccCode.PubSub.Tests.Integration
{
    public class ApiTestBase
        : IClassFixture<ApiTestApplicationFactory<Program>>
    {
        protected ApiTestApplicationFactory<Program> Factory { get; }

        public ApiTestBase(ApiTestApplicationFactory<Program> factory)
        {
            Factory = factory;
        }

        protected HttpClient CreateClient(params string[] scopes) {
            var client = Factory.CreateClient();
            if (scopes != null && scopes.Length > 0)
            {
                client.DefaultRequestHeaders.Add("X-TEST-AUTH-SCOPE", scopes);
            }

            return client;
        }

        protected IHttpClientFactory CreateClientFactory(params string[] scopes) => new HttpClientFactory(CreateClient(scopes)) ;

        protected class HttpClientFactory : IHttpClientFactory
        {
            private readonly HttpClient _client;

            public HttpClientFactory(HttpClient client)
            {
                _client = client;
            }
            public HttpClient CreateClient(string name)
            {
                return _client ?? new HttpClient();
            }
        }
    }
}
