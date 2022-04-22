using MassTransit;
using Microsoft.AspNetCore.Mvc;
using QueueMasstransitTutorial.Shared.Events;
using System.Threading.Tasks;

namespace QueueMasstransitTutorial.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public HomeController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string email)
        {
            await _publishEndpoint.Publish(new AddedUserEvent { Email = email });

            return Ok();
        }
    }
}
