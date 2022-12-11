using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public class VideoRepository : IVideoRepository
    {
        public Task AddAsync(Video video)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid videoId)
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetByIdAsync(Guid videoId)
        {
            throw new NotImplementedException();
        }
    }
}
