namespace VideoMonitor.Services
{
    public interface IPingService
    {
        Task<bool> IsAvailableAsync(string ip, int port);
    }
}
