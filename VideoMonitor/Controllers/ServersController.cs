using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Models;
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
        public async Task<Results<BadRequest, Created<ServerGetResource>>> AddAsync(ServerAddResource serverAddResource)
        {
            try
            {
                var server = await _serverService.AddAsync(serverAddResource);
                
                var location = Url.Action(nameof(GetByIdAsync), new { id = server.Id }) ?? $"/{server.Id}";

                var serverGetResource = new ServerGetResource()
                {
                    Id = server.Id,
                    Ip = server.Ip,
                    Name = server.Name,
                    Port = server.Port
                };
                return TypedResults.Created(location, serverGetResource);
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpDelete]
        [Route("{serverId}​")]
        public async Task<Results<BadRequest, NotFound, Ok>> DeleteAsync(Guid serverId)
        {
            try
            {
                await _serverService.DeleteAsync(serverId);
                return TypedResults.Ok();
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpGet]
        [Route("{serverId}​")]
        public async Task<Results<BadRequest, NotFound, Ok<ServerGetResource>>> GetByIdAsync(Guid serverId)
        {
            try
            {
                var server = await _serverService.GetByIdAsync(serverId);

                if (server is null || server.Id == Guid.Empty)
                    return TypedResults.NotFound();

                return TypedResults.Ok(new ServerGetResource()
                {
                    Id = server.Id,
                    Ip = server.Ip,
                    Name = server.Name,
                    Port = server.Port
                });
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpGet]
        [Route("available/{serverId}")]
        public async Task<Results<BadRequest, NotFound, Ok<bool>>> IsAvailableAsync(Guid serverId)
        {
            try
            {
                return TypedResults.Ok(await _serverService.IsAvailableAsync(serverId));
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
        }

        [HttpGet]
        public async Task<Results<BadRequest, NoContent, Ok<IEnumerable<ServerGetResource>>>> GetAllAsync()
        {
            try
            {
                var servers = await _serverService.GetAllAsync();

                if (!servers.Any())
                    return TypedResults.NoContent();

                return TypedResults.Ok(servers.Select(x => new ServerGetResource
                {
                    Id = x.Id,
                    Ip = x.Ip,
                    Name = x.Name,
                    Port = x.Port
                }));
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
        }
    }
}
