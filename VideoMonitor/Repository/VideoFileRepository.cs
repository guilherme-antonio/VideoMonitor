namespace VideoMonitor.Repository
{
    public class VideoFileRepository : IVideoFileRepository
    {
        private string _path = $".{Path.DirectorySeparatorChar}videos";

        public async Task<string> GetVideoBinaryAsync(Guid videoId)
        {
            return Convert.ToBase64String(await File.ReadAllBytesAsync($"{_path}{Path.DirectorySeparatorChar}{videoId}"));
        }

        public async Task SaveToFileAsync(Guid videoId, string binary)
        {
            Directory.CreateDirectory(_path);
            await File.Create($"{_path}{Path.DirectorySeparatorChar}{videoId}")
                .WriteAsync(Convert.FromBase64String(binary));
        }
    }
}
