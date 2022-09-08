using BccCode.PubSub.Tests.Fakes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BccCode.PubSub.Tests.Helpers
{
    public class ApiTestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureTestServices(services =>
            {
                services.Configure<ApiTestAuthenticationOptions>(options => { });

                services.AddAuthentication(ApiTestAuthenticationHandler.AuthenticationScheme)
                        .AddScheme<ApiTestAuthenticationOptions, ApiTestAuthenticationHandler>(ApiTestAuthenticationHandler.AuthenticationScheme, options => { });
            });

            base.ConfigureWebHost(builder);
        }


        protected override void ConfigureClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
            base.ConfigureClient(client);
        }


    }
}
