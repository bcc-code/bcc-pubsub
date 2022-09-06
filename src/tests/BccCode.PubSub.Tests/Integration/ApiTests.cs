using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BccCode.PubSub.Tests.Integration
{
    public class ApiTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        protected  WebApplicationFactory<Program> Factory { get; }

        public ApiTests(WebApplicationFactory<Program> factory)
        {
            Factory = factory;
        }

        protected HttpClient CreateClient() => Factory.CreateClient();

        protected IHttpClientFactory CreateClientFactory() => new HttpClientFactory(CreateClient()) ;

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
