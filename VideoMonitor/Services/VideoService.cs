using VideoMonitor.Models;
using VideoMonitor.Repository;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task AddAsync(VideoResource videoResource, Guid serverId)
        {
            var video = new Video()
            {
                Description= videoResource.Description
            };
            await _videoRepository.AddAsync(video);
        }

        public async Task DeleteAsync(Guid videoId)
        {
            await _videoRepository.DeleteAsync(videoId);
        }

        public Task<byte[]> GetBinaryByIdAsync(Guid videoId)
        {
            throw new NotImplementedException();
        }

        public async Task<Video> GetByIdAsync(Guid videoId)
        {
            return await _videoRepository.GetByIdAsync(videoId);
        }
    }
}
