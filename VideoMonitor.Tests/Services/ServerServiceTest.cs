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
        public void AddServer_IsValidServer_AddOnRepository()
        {
            var server = new Server();

            _serverService.Add(server);

            _serverRepository.Verify(x => x.Add(server));
        }
    }
}
