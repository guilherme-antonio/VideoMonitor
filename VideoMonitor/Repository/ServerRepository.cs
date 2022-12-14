using Microsoft.EntityFrameworkCore;
using VideoMonitor.Context;
using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public class ServerRepository : IServerRepository
    {
        private readonly VideoMonitorContext _context;

        private DbSet<Server> _servers { get; set; }

        public ServerRepository(VideoMonitorContext context)
        {
            _servers = context.Servers;
            _context = context;
        }

        public async Task<Server> AddAsync(Server server)
        {
            var newServer = await _servers.AddAsync(server);
            await _context.SaveChangesAsync();

            return newServer.Entity;
        }

        public async Task DeleteAsync(Guid serverId)
        {
            await _servers.Where(x => x.Id == serverId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Server>> GetAllAsync()
        {
            return await _servers.ToListAsync();
        }

        public async Task<Server> GetByIdAsync(Guid serverId)
        {
            return await _servers.Where(x => x.Id == serverId).FirstOrDefaultAsync();
        }

        public async Task<string> GetIpByIdAsync(Guid serverId)
        {
            return await _servers.Where(x => x.Id == serverId)
                .Select(x =>x.Ip).FirstOrDefaultAsync();
        }
    }
}
