using BccCode.PubSub.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BccCode.PubSub.Tests.Integration
{
    public class SubscriptionsApiTests : ApiTestBase
    {
        public SubscriptionsApiTests(ApiTestApplicationFactory<Program> factory) : base(factory)
        {
            
        }

        [Fact]
        public async Task Subscriptions_GetAll_ReturnsAllSubscriptions()
        {
            var client = CreateClient(Scopes.Subscribe);

            var result = await client.GetStringAsync("/subscriptions");


        }
    }
}