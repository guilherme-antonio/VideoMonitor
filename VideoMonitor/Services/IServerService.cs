using VideoMonitor.Models;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public interface IServerService
    {
        Task AddAsync(ServerAddResource serverAddResource);
        Task DeleteAsync(Guid serverId);
        Task<Server> GetByIdAsync(Guid serverId);
        Task<bool> IsAvailableAsync(Guid serverId);
        Task<IEnumerable<Server>> GetAllAsync();
    }
}
