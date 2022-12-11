using VideoMonitor.Domain;

namespace VideoMonitor.Repository
{
    public interface IVideoRepository
    {
        Task AddAsync(Video video);
        Task DeleteAsync(Guid videoId);
    }
}
