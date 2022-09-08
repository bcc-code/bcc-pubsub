using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BccCode.PubSub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Scopes.Subscribe)]
    public class SubscriptionsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SubscriptionsController> _logger;

        public SubscriptionsController(ILogger<SubscriptionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSubscriptions")]
        public IEnumerable<Subscription> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Subscription
            {
                SubscriptionId = Guid.NewGuid()
            })
            .ToArray();
        }
    }
}