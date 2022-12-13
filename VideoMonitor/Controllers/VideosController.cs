using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Models;
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
        public async Task<Results<BadRequest, Created<VideoGetResource>>> AddAsync(Guid serverId, VideoAddResource videoResource)
        {
            try
            {
                var video = await _videoService.AddAsync(videoResource, serverId);

                var location = Url.Action(nameof(GetByIdAsync), new { id = video.Id }) ?? $"/{video.Id}";

                var videoGetResource = new VideoGetResource()
                {
                    Id = video.Id,
                    Description = video.Description,
                    ServerId = video.ServerId
                };
                return TypedResults.Created(location, videoGetResource);
            }
            catch (Exception e)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpDelete]
        [Route("{videoId}​")]
        public async Task<Results<BadRequest, NotFound, Ok>> DeleteAsync(Guid serverId, Guid videoId)
        {
            try
            {
                await _videoService.DeleteAsync(videoId, serverId);
                return TypedResults.Ok();
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpGet]
        [Route("{videoId}​")]
        public async Task<Results<BadRequest, NotFound, Ok<VideoGetResource>>> GetByIdAsync(Guid serverId, Guid videoId)
        {
            try
            {
                var video = await _videoService.GetByIdAsync(videoId, serverId);

                if (video is null || video.Id == Guid.Empty)
                    return TypedResults.NotFound();

                return TypedResults.Ok(new VideoGetResource()
                {
                    Id = video.Id,
                    Description = video.Description,
                    ServerId = video.ServerId
                });
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpGet]
        [Route("{videoId}/binary​")]
        public async Task<Results<BadRequest, NotFound, Ok<string>>> GetBinaryByIdAsync(Guid serverId, Guid videoId)
        {
            try
            {
                var binary = await _videoService.GetBinaryByIdAsync(videoId, serverId);
                
                if (string.IsNullOrWhiteSpace(binary))
                    return TypedResults.NotFound();

                return TypedResults.Ok(binary);
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
        }

        [HttpGet]
        public async Task<Results<BadRequest, NoContent, Ok<IEnumerable<VideoGetResource>>>> GetAllAsync(Guid serverId)
        {
            try
            {
                var videos = await _videoService.GetAllAsync(serverId);

                if (!videos.Any())
                    return TypedResults.NoContent();

                return TypedResults.Ok(videos.Select(x => new VideoGetResource
                {
                    Id = x.Id,
                    Description = x.Description,
                    ServerId = x.ServerId
                }));
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }
    }
}
