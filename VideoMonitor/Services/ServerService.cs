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

        public void Add(Server server)
        {
            _serverRepository.Add(server);
        }
    }
}
