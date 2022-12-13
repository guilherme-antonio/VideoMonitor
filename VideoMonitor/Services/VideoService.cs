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
                Description = videoResource.Description
            };
            var videoCreated = await _videoRepository.AddAsync(video);

            await _videoFileRepository.SaveToFileAsync(videoCreated.Id, videoResource.Binary);

            return videoCreated;
        }

        public async Task DeleteAsync(Guid videoId)
        {
            await _videoRepository.DeleteAsync(videoId);
        }

        public async Task<IEnumerable<Video>> GetAllAsync()
        {
            return await _videoRepository.GetAllAsync();
        }

        public async Task<string> GetBinaryByIdAsync(Guid videoId)
        {
            return await _videoFileRepository.GetVideoBinaryAsync(videoId);
        }

        public async Task<Video> GetByIdAsync(Guid videoId)
        {
            return await _videoRepository.GetByIdAsync(videoId);
        }
    }
}
