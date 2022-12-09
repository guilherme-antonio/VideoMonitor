using System.Net.NetworkInformation;

namespace VideoMonitor.Services
{
    public class PingService : IPingService
    {
        public async Task<bool> IsAvailableAsync(string host, int port)
        {
            var ping = new Ping();

            var pingReply = await ping.SendPingAsync($"{host}:{port}");

            return pingReply.Status == IPStatus.Success;
        }
    }
}
