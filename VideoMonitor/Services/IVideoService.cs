using VideoMonitor.Models;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public interface IVideoService
    {
        Task AddAsync(VideoResource videoResource, Guid serverId);
        Task DeleteAsync(Guid videoId);
        Task<byte[]> GetBinaryByIdAsync(Guid videoId);
        Task<Video> GetByIdAsync(Guid videoId);
    }
}
