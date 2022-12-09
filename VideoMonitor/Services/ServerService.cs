using VideoMonitor.Domain;
using VideoMonitor.Repository;

namespace VideoMonitor.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;

        public ServerService(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
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
    }
}
