namespace VideoMonitor.Repository
{
    public interface IVideoFileRepository
    {
        Task<string> GetVideoBinaryAsync(Guid videoId);
        Task SaveToFileAsync(Guid videoId, string binary);
    }
}
