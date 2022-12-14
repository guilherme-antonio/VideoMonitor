using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public interface IServerRepository
    {
        Task<Server> AddAsync(Server server);
        Task DeleteAsync(Guid serverId);
        Task<IEnumerable<Server>> GetAllAsync();
        Task<Server> GetByIdAsync(Guid serverId);
        Task<string> GetIpByIdAsync(Guid serverId);
    }
}
