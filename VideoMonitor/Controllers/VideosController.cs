using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Domain;
using VideoMonitor.Services;

namespace VideoMonitor.Controllers
{
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost(Name = "servers/{serverId}/videos​")]
        public async Task AddAsync(Guid serverId, Video video)
        {
            await _videoService.AddAsync(video);
        }

        [HttpDelete(Name = "/api/servers/{serverId}/videos/{videoId}​")]
        public async Task DeleteAsync(Guid serverId, Guid videoId)
        {
            await _videoService.DeleteAsync(videoId);
        }

        [HttpGet(Name = "/api/servers/{serverId}/videos/{videoId}​")]
        public async Task<Video> GetByIdAsync(Guid serverId, Guid videoId)
        {
            return await _videoService.GetByIdAsync(videoId);
        }
    }
}
