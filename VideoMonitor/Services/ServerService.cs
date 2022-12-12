using VideoMonitor.Models;
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

        public async Task<IEnumerable<Server>> GetAllAsync()
        {
            return await _serverRepository.GetAllAsync();
        }

        public async Task<Server> GetByIdAsync(Guid serverId)
        {
            return await _serverRepository.GetByIdAsync(serverId);
        }

        public async Task<bool> IsAvailableAsync(Guid serverId)
        {
            (var ip, var port) = await _serverRepository.GetIpAndPortByIdAsync(serverId);

            return await _pingService.IsAvailableAsync(ip, port);
        }
    }
}
