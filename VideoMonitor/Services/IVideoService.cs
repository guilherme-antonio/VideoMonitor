using VideoMonitor.Models;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public interface IVideoService
    {
        Task AddAsync(VideoAddResource videoResource, Guid serverId);
        Task DeleteAsync(Guid videoId);
        Task<IEnumerable<Video>> GetAllAsync();
        Task<byte[]> GetBinaryByIdAsync(Guid videoId);
        Task<Video> GetByIdAsync(Guid videoId);
    }
}
