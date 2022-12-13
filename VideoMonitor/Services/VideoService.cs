using VideoMonitor.Models;
using VideoMonitor.Repository;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoFileRepository _videoFileRepository;

        public VideoService(IVideoRepository videoRepository, IVideoFileRepository videoFileRepository)
        {
            _videoRepository = videoRepository;
            _videoFileRepository = videoFileRepository;
        }

        public async Task<Video> AddAsync(VideoAddResource videoResource, Guid serverId)
        {
            var video = new Video()
            {
                Description = videoResource.Description,
                ServerId = serverId
            };
            var videoCreated = await _videoRepository.AddAsync(video);

            await _videoFileRepository.SaveToFileAsync(videoCreated.Id, videoResource.Binary, serverId);

            return videoCreated;
        }

        public async Task DeleteAsync(Guid videoId, Guid serverId)
        {
            await _videoRepository.DeleteAsync(videoId, serverId);
            await _videoFileRepository.DeleteVideoFileAsync(videoId, serverId);
        }

        public async Task<IEnumerable<Video>> GetAllAsync(Guid serverId)
        {
            return await _videoRepository.GetAllAsync(serverId);
        }

        public async Task<string> GetBinaryByIdAsync(Guid videoId, Guid serverId)
        {
            return await _videoFileRepository.GetVideoBinaryAsync(videoId, serverId);
        }

        public async Task<Video> GetByIdAsync(Guid videoId, Guid serverId)
        {
            return await _videoRepository.GetByIdAsync(videoId, serverId);
        }
    }
}
