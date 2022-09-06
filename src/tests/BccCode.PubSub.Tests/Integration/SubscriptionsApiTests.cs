using Microsoft.AspNetCore.Mvc.Testing;

namespace BccCode.PubSub.Tests.Integration
{
    public class SubscriptionsApiTests : ApiTests
    {
        public SubscriptionsApiTests(WebApplicationFactory<Program> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Subscriptions_GetAll_ReturnsAllSubscriptions()
        {
            var client = CreateClient();

            var result = await client.GetStringAsync("/subscriptions");


        }
    }
}