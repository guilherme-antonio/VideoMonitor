using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public interface IVideoRepository
    {
        Task<Video> AddAsync(Video video);
        Task DeleteAsync(Guid videoId, Guid serverId);
        Task<IEnumerable<Video>> GetAllAsync(Guid serverId);
        Task<Video> GetByIdAsync(Guid videoId, Guid serverId);
    }
}
