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
        public async Task AddAsync(Video video)
        {
            await _videoService.AddAsync(video);
        }
    }
}
