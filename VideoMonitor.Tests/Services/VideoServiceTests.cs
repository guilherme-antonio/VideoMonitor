﻿using FluentAssertions;
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

        public VideoServiceTests()
        {
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_videoRepository.Object);
        }

        [Fact]
        public async Task AddAsync_IsValidVideo_AddOnRepository()
        {
            var description = "video";
            var video = new VideoResource()
            {
                Description= description
            };
            var serverId = Guid.NewGuid();

            await _videoService.AddAsync(video, serverId);

            _videoRepository.Verify(x => x.AddAsync(It.Is<Video>(x => video.Description == description)));
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
    }
}
