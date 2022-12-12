using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using VideoMonitor.Context;
using VideoMonitor.Models;

namespace VideoMonitor.Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly VideoMonitorContext _context;

        private DbSet<Video> _videos { get; set; }

        public VideoRepository(VideoMonitorContext context)
        {
            _videos = context.Videos;
            _context = context;
        }

        public async Task<Guid> AddAsync(Video video)
        {
            var newVideo = await _videos.AddAsync(video);
            await _context.SaveChangesAsync();
            return newVideo.Entity.Id;
        }

        public async Task DeleteAsync(Guid videoId)
        {
            await _videos.Where(x => x.Id == videoId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<Video> GetByIdAsync(Guid videoId)
        {
            return await _videos.Where(x => x.Id == videoId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _videos.ToListAsync();
        }
    }
}
