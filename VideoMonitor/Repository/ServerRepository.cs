using Microsoft.EntityFrameworkCore;
using VideoMonitor.Context;
using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public class ServerRepository : IServerRepository
    {
        private DbSet<Server> _servers { get; set; }

        public ServerRepository(VideoMonitorContext context)
        {
            _servers = context.Servers;
        }

        public async Task AddAsync(Server server)
        {
            await _servers.AddAsync(server);
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
