using System.Net.NetworkInformation;

namespace VideoMonitor.Services
{
    public class PingService : IPingService
    {
        public async Task<bool> IsAvailableAsync(string ip)
        {
            var ping = new Ping();

            var pingReply = await ping.SendPingAsync($"{ip}");

            return pingReply.Status == IPStatus.Success;
        }
    }
}
