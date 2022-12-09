using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Domain;

namespace VideoMonitor.Controllers
{
    [ApiController]
    public class ServerController : ControllerBase
    {
        [HttpGet(Name = "servers")]
        public IEnumerable<Server> Get()
        {
            return new List<Server>();
        }
    }
}
