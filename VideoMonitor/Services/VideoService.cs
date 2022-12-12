using VideoMonitor.Models;
using VideoMonitor.Repository;
using VideoMonitor.Resources;

namespace VideoMonitor.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private string _path = $".{Path.DirectorySeparatorChar}videos";

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task AddAsync(VideoAddResource videoResource, Guid serverId)
        {
            var video = new Video()
            {
                Description = videoResource.Description
            };
            var videoId = await _videoRepository.AddAsync(video);
            Directory.CreateDirectory(_path);
            await File.Create($"{_path}{Path.DirectorySeparatorChar}{videoId}")
                .WriteAsync(Convert.FromBase64String(videoResource.Binary));
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
            return Convert.ToBase64String(await File.ReadAllBytesAsync($"{_path}{Path.DirectorySeparatorChar}{videoId}"));
        }

        public async Task<Video> GetByIdAsync(Guid videoId)
        {
            return await _videoRepository.GetByIdAsync(videoId);
        }
    }
}
