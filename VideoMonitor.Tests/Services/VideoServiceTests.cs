using FluentAssertions;
using Moq;
using VideoMonitor.Models;
using VideoMonitor.Repository;
using VideoMonitor.Resources;
using VideoMonitor.Services;
using Xunit;

namespace VideoMonitor.Tests.Services
{
    public class VideoServiceTests
    {
        private readonly IVideoService _videoService;
        private readonly Mock<IVideoRepository> _videoRepository;
        private readonly Mock<IVideoFileRepository> _fileRepository;

        public VideoServiceTests()
        {
            _videoRepository = new Mock<IVideoRepository>();
            _fileRepository = new Mock<IVideoFileRepository>();
            _videoService = new VideoService(_videoRepository.Object, _fileRepository.Object);
        }

        [Fact]
        public async Task AddAsync_IsValidVideo_AddOnRepository()
        {
            var description = "video";
            var binary = "2131231231==";
            var video = new VideoAddResource()
            {
                Description = description,
                Binary = binary
            };
            var serverId = Guid.NewGuid();
            var videoId = Guid.NewGuid();

            _videoRepository.Setup(x => x.AddAsync(It.Is<Video>(x => video.Description == description))).ReturnsAsync(videoId);

            await _videoService.AddAsync(video, serverId);

            _videoRepository.Verify(x => x.AddAsync(It.Is<Video>(x => video.Description == description)));
            _fileRepository.Verify(x => x.SaveToFileAsync(videoId, binary));
        }

        [Fact]
        public async Task DeleteAsync_ReceiveVideoId_DeleteFromRepositoryByVideoId()
        {
            var videoId = Guid.NewGuid();

            await _videoService.DeleteAsync(videoId);

            _videoRepository.Verify(x => x.DeleteAsync(videoId));
        }

        [Fact]
        public async Task GetByIdAsync_ReceiveVideoId_RetrieveVideoWithVideoId()
        {
            var videoId = Guid.NewGuid();

            var video = new Video();

            _videoRepository.Setup(x => x.GetByIdAsync(videoId)).ReturnsAsync(video);

            var retrievedVideo = await _videoService.GetByIdAsync(videoId);

            _videoRepository.Verify(x => x.GetByIdAsync(videoId));

            retrievedVideo.Should().Be(video);
        }

        [Fact]
        public async Task GetAllAsync_ExistsVideos_ReturnAllVideos()
        {
            var videos = new List<Video>();

            _videoRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(videos);

            var returnedVideos = await _videoService.GetAllAsync();

            returnedVideos.Should().BeSameAs(videos);
        }
    }
}
