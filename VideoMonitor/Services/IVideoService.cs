using VideoMonitor.Models;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public interface IVideoService
    {
        Task<Video> AddAsync(VideoAddResource videoResource, Guid serverId);
        Task DeleteAsync(Guid videoId, Guid serverId);
        Task<IEnumerable<Video>> GetAllAsync(Guid serverId);
        Task<string> GetBinaryByIdAsync(Guid videoId, Guid serverId);
        Task<Video> GetByIdAsync(Guid videoId, Guid serverId);
    }
}
