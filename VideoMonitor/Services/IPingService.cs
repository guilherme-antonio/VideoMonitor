namespace VideoMonitor.Services
{
    public interface IPingService
    {
        Task<bool> IsAvailableAsync(string host, int port);
    }
}
