using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Models;
using VideoMonitor.Services;
using VideoMonitor.Resources;

namespace VideoMonitor.Controllers
{
    [ApiController]
    [Route("servers/{serverId}/[controller]")]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        public async Task AddAsync(Guid serverId, VideoResource videoResource)
        {
            await _videoService.AddAsync(videoResource, serverId);
        }

        [HttpDelete]
        [Route("{videoId}​")]
        public async Task DeleteAsync(Guid serverId, Guid videoId)
        {
            await _videoService.DeleteAsync(videoId);
        }

        [HttpGet]
        [Route("{videoId}​")]
        public async Task<Video> GetByIdAsync(Guid serverId, Guid videoId)
        {
            return await _videoService.GetByIdAsync(videoId);
        }

        [HttpGet]
        [Route("{videoId}/binary​")]
        public async Task<FileContentResult> GetBinaryByIdAsync(Guid serverId, Guid videoId)
        {
            return File(await _videoService.GetBinaryByIdAsync(videoId), "video/mp4") ;
        }
    }
}
