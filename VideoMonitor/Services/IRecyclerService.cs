using VideoMonitor.Enums;

namespace VideoMonitor.Services
{
    public interface IRecyclerService
    {
        Task<RecyclerStatus> GetStatusAsync();
        Task ProcessAsync(int days);
    }
}
