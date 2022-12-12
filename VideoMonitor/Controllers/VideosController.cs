using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Resources;
using VideoMonitor.Services;

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
        public async Task AddAsync(Guid serverId, VideoAddResource videoResource)
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
        public async Task<VideoGetResource> GetByIdAsync(Guid serverId, Guid videoId)
        {
            var video = await _videoService.GetByIdAsync(videoId);
            return new VideoGetResource()
            {
                Id = video.Id,
                Description = video.Description
            };
        }

        [HttpGet]
        [Route("{videoId}/binary​")]
        public async Task<FileContentResult> GetBinaryByIdAsync(Guid serverId, Guid videoId)
        {
            return File(await _videoService.GetBinaryByIdAsync(videoId), "video/mp4") ;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoGetResource>> GetAllAsync()
        {
            return (await _videoService.GetAllAsync()).Select(x => new VideoGetResource
            {
                Id = x.Id,
                Description = x.Description
            });
        }
    }
}
