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

        public async Task<Video> AddAsync(Video video)
        {
            var newVideo = await _videos.AddAsync(video);
            await _context.SaveChangesAsync();
            return newVideo.Entity;
        }

        public async Task DeleteAsync(Guid videoId, Guid serverId)
        {
            await _videos.Where(x => x.ServerId == serverId && x.Id == videoId).ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
        }

        public async Task<Video> GetByIdAsync(Guid videoId, Guid serverId)
        {
            return await _videos.Where(x => x.ServerId == serverId && x.Id == videoId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Video>> GetAllAsync(Guid serverId)
        {
            return await _videos.Where(x => x.ServerId == serverId).ToListAsync();
        }
    }
}
