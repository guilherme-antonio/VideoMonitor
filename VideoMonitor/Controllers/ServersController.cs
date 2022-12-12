using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Resources;
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
        public async Task AddAsync(ServerAddResource serverAddResource)
        {
            await _serverService.AddAsync(serverAddResource);
        }

        [HttpDelete]
        [Route("{serverId}​")]
        public async Task DeleteAsync(Guid serverId)
        {
            await _serverService.DeleteAsync(serverId);
        }

        [HttpGet]
        [Route("{serverId}​")]
        public async Task<ServerGetResource> GetByIdAsync(Guid serverId)
        {
            var server = await _serverService.GetByIdAsync(serverId);

            return new ServerGetResource()
            {
                Id = server.Id,
                Ip = server.Ip,
                Name = server.Name,
                Port = server.Port
            };
        }

        [HttpGet]
        [Route("available/{serverId}")]
        public async Task<bool> IsAvailableAsync(Guid serverId)
        {
            return await _serverService.IsAvailableAsync(serverId);
        }

        [HttpGet]
        public async Task<IEnumerable<ServerGetResource>> GetAllAsync()
        {
            return (await _serverService.GetAllAsync()).Select(x => new ServerGetResource
            {
                Id= x.Id,
                Ip= x.Ip,
                Name= x.Name,
                Port = x.Port
            });
        }
    }
}
