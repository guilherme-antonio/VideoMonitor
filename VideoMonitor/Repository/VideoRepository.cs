using Microsoft.EntityFrameworkCore;
using VideoMonitor.Context;
using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private DbSet<Video> _videos { get; set; }

        public VideoRepository(VideoMonitorContext context)
        {
            _videos = context.Videos;
        }

        public async Task AddAsync(Video video)
        {
            await _videos.AddAsync(video);
        }

        public Task DeleteAsync(Guid videoId)
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetByIdAsync(Guid videoId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _videos.ToListAsync();
        }
    }
}
