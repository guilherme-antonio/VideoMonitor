using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public interface IVideoRepository
    {
        Task<Guid> AddAsync(Video video);
        Task DeleteAsync(Guid videoId);
        Task<IEnumerable<Video>> GetAllAsync();
        Task<Video> GetByIdAsync(Guid videoId);
    }
}
