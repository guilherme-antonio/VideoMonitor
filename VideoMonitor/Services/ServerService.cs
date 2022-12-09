using System.Net;
using System.Net.NetworkInformation;
using VideoMonitor.Domain;
using VideoMonitor.Repository;

namespace VideoMonitor.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly IPingService _pingService;

        public ServerService(IServerRepository serverRepository, IPingService pingService)
        {
            _serverRepository = serverRepository;
            _pingService = pingService;
        }

        public async Task AddAsync(Server server)
        {
            await _serverRepository.AddAsync(server);
        }

        public async Task DeleteAsync(Guid serverId)
        {
            await _serverRepository.DeleteAsync(serverId);
        }

        public async Task<Server> GetByIdAsync(Guid serverId)
        {
            return await _serverRepository.GetByIdAsync(serverId);
        }

        public async Task<bool> IsAvailableAsync(Guid serverId)
        {
            (var host, var port) = await _serverRepository.GetHostAndPortByIdAsync(serverId);

            return await _pingService.IsAvailableAsync(host, port);
        }
    }
}
