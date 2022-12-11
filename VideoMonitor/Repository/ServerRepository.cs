using VideoMonitor.Domain;

namespace VideoMonitor.Repository
{
    public class ServerRepository : IServerRepository
    {
        public Task AddAsync(Server server)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid serverId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Server>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Server> GetByIdAsync(Guid serverId)
        {
            throw new NotImplementedException();
        }

        public Task<(string, int)> GetHostAndPortByIdAsync(Guid serverId)
        {
            throw new NotImplementedException();
        }
    }
}
