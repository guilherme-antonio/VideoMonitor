using VideoMonitor.Domain;

namespace VideoMonitor.Services
{
    public interface IVideoService
    {
        Task AddAsync(Video video);
        Task DeleteAsync(Guid videoId);
        Task<byte[]> GetBinaryByIdAsync(Guid videoId);
        Task<Video> GetByIdAsync(Guid videoId);
    }
}
