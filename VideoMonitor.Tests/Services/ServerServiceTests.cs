using FluentAssertions;
using Moq;
using VideoMonitor.Models;
using VideoMonitor.Repository;
using VideoMonitor.Resources;
using VideoMonitor.Services;
using Xunit;

namespace VideoMonitor.Tests.Services
{
    public class ServerServiceTests
    {
        private readonly IServerService _serverService;
        private readonly Mock<IServerRepository> _serverRepository;
        private readonly Mock<IPingService> _pingService;

        public ServerServiceTests()
        {
            _serverRepository = new Mock<IServerRepository>();
            _pingService = new Mock<IPingService>();
            _serverService = new ServerService(_serverRepository.Object, _pingService.Object);
        }

        [Fact]
        public async Task AddAsync_IsValidServer_AddOnRepository()
        {
            var name = "name";
            var ip = "127.0.0.1";
            var port = 80;

            var serverAddResource = new ServerAddResource()
            {
                Name = name,
                Ip= ip,
                Port = port
            };

            await _serverService.AddAsync(serverAddResource);

            _serverRepository.Verify(x => x.AddAsync(It.Is<Server>(x => 
                x.Name == name &&
                x.Ip == ip &&
                x.Port == port)));
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

        [Fact]
        public async Task IsAvailableAsync_FoundServerById_CallPingServiceWithServerIp()
        {
            var serverId = Guid.NewGuid();

            var ip = "172.0.0.1";

            var isAvailable = true;

            _serverRepository.Setup(x => x.GetIpByIdAsync(serverId)).ReturnsAsync(ip);
            _pingService.Setup(x => x.IsAvailableAsync(ip)).ReturnsAsync(isAvailable);

            var isAvailableReturn = await _serverService.IsAvailableAsync(serverId);

            _serverRepository.Verify(x => x.GetIpByIdAsync(serverId));
            _pingService.Verify(x => x.IsAvailableAsync(ip));

            isAvailableReturn.Should().Be(isAvailable);
        }

        [Fact]
        public async Task GetAllAsync_ExistsServers_ReturnAllServers()
        {
            var servers = new List<Server>();

            _serverRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(servers);

            var returnedServers =  await _serverService.GetAllAsync();

            returnedServers.Should().BeSameAs(servers);
        }
    }
}
