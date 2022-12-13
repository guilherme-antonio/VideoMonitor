namespace VideoMonitor.Repository
{
    public interface IVideoFileRepository
    {
        Task DeleteVideoFileAsync(Guid videoId, Guid serverId);
        Task<string> GetVideoBinaryAsync(Guid videoId, Guid serverId);
        Task RemoveOldVideosAsync(int days);
        Task SaveToFileAsync(Guid videoId, string binary, Guid serverId);
    }
}
