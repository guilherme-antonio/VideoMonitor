using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Domain;
using VideoMonitor.Services;

namespace VideoMonitor.Controllers
{
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IServerService _serverService;

        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpPost(Name = "server​")]
        public async Task AddAsync(Server server)
        {
            await _serverService.AddAsync(server);
        }

        [HttpDelete(Name = "servers/{serverId}​")]
        public async Task DeleteAsync(Guid serverId)
        {
            await _serverService.DeleteAsync(serverId);
        }

        [HttpGet(Name = "servers/{serverId}​")]
        public async Task<Server> GetByIdAsync(Guid serverId)
        {
            return await _serverService.GetByIdAsync(serverId);
        }

        [HttpGet(Name = "servers")]
        public async Task<IEnumerable<Server>> GetAsync()
        {
            return new List<Server>();
        }
    }
}
