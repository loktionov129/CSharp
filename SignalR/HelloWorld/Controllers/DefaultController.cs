using HelloWorld.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _ctx;

        public DefaultController(IHubContext<ChatHub> ctx)
        {
            _ctx = ctx;
        }

        public ActionResult Get()
        {
            _ctx.Clients.All.SendAsync("broadcastMessage", "SYSTEM", "Hello");
            return Ok("Notified.");
        }
    }
}