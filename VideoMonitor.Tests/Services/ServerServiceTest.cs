using FluentAssertions;
using Moq;
using VideoMonitor.Domain;
using VideoMonitor.Repository;
using VideoMonitor.Services;
using Xunit;

namespace VideoMonitor.Tests.Services
{
    public class ServerServiceTest
    {
        private readonly IServerService _serverService;
        private readonly Mock<IServerRepository> _serverRepository;

        public ServerServiceTest()
        {
            _serverRepository = new Mock<IServerRepository>();
            _serverService = new ServerService(_serverRepository.Object);
        }

        [Fact]
        public async Task AddAsync_IsValidServer_AddOnRepository()
        {
            var server = new Server();

            await _serverService.AddAsync(server);

            _serverRepository.Verify(x => x.AddAsync(server));
        }

        [Fact]
        public async Task DeleteAsync_ReceiveServerId_DeleteFromRepositoryByServerId()
        {
            var serverId = Guid.NewGuid();

            await _serverService.DeleteAsync(serverId);

            _serverRepository.Verify(x => x.DeleteAsync(serverId));
        }

        [Fact]
        public async Task GetByIdAsync_ReceiveServerId_RetrieveServerWithServerId()
        {
            var serverId = Guid.NewGuid();

            var server = new Server();

            _serverRepository.Setup(x => x.GetByIdAsync(serverId)).ReturnsAsync(server);

            var retrievedServer = await _serverService.GetByIdAsync(serverId);

            _serverRepository.Verify(x => x.GetByIdAsync(serverId));

            retrievedServer.Should().Be(server);
        }
    }
}
