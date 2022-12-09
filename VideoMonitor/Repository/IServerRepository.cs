using VideoMonitor.Domain;

namespace VideoMonitor.Repository
{
    public interface IServerRepository
    {
        Task AddAsync(Server server);
        Task DeleteAsync(Guid serverId);
        Task<Server> GetByIdAsync(Guid serverId);
        Task<(string, int)> GetHostAndPortByIdAsync(Guid serverId);
    }
}
