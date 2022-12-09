using VideoMonitor.Domain;

namespace VideoMonitor.Services
{
    public interface IServerService
    {
        Task AddAsync(Server server);
        Task DeleteAsync(Guid serverId);
        Task<Server> GetByIdAsync(Guid serverId);
        Task<bool> IsAvailableAsync(Guid serverId);
    }
}
