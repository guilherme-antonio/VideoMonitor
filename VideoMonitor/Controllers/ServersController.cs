using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Models;
using VideoMonitor.Services;

namespace VideoMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServersController : ControllerBase
    {
        private readonly IServerService _serverService;

        public ServersController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpPost]
        public async Task AddAsync(Server server)
        {
            await _serverService.AddAsync(server);
        }

        [HttpDelete]
        [Route("{serverId}​")]
        public async Task DeleteAsync(Guid serverId)
        {
            await _serverService.DeleteAsync(serverId);
        }

        [HttpGet]
        [Route("{serverId}​")]
        public async Task<Server> GetByIdAsync(Guid serverId)
        {
            return await _serverService.GetByIdAsync(serverId);
        }

        [HttpGet]
        [Route("available/{serverId}")]
        public async Task<bool> IsAvailableAsync(Guid serverId)
        {
            return await _serverService.IsAvailableAsync(serverId);
        }

        [HttpGet]
        public async Task<IEnumerable<Server>> GetAllAsync()
        {
            return await _serverService.GetAllAsync();
        }
    }
}
