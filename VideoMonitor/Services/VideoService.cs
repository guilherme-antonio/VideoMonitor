using VideoMonitor.Domain;
using VideoMonitor.Repository;

namespace VideoMonitor.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task AddAsync(Video video)
        {
            await _videoRepository.AddAsync(video);
        }

        public async Task DeleteAsync(Guid videoId)
        {
            await _videoRepository.DeleteAsync(videoId);
        }

        public async Task<Video> GetByIdAsync(Guid videoId)
        {
            return await _videoRepository.GetByIdAsync(videoId);
        }
    }
}
