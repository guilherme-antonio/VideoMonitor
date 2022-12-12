using VideoMonitor.Enums;
using VideoMonitor.Repository;

namespace VideoMonitor.Services
{
    public class RecyclerService : IRecyclerService
    {
        private readonly IVideoFileRepository _videoFileRepository;
        private RecyclerStatus _status;

        public RecyclerService(IVideoFileRepository videoFileRepository)
        {
            _videoFileRepository = videoFileRepository;
        }

        public async Task<RecyclerStatus> GetStatusAsync()
        {
            return _status;
        }

        public async Task ProcessAsync(int days)
        {
            if (_status == RecyclerStatus.Running)
                return;

            _status = RecyclerStatus.Running;
            await _videoFileRepository.RemoveOldVideosAsync(days);
            _status = RecyclerStatus.NotRunning;
        }
    }
}
