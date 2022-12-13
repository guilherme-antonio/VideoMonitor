namespace VideoMonitor.Repository
{
    public class VideoFileRepository : IVideoFileRepository
    {
        private string _path = $".{Path.DirectorySeparatorChar}videos";

        public async Task<string> GetVideoBinaryAsync(Guid videoId, Guid serverId)
        {
            return Convert.ToBase64String(await File.ReadAllBytesAsync($"{_path}{Path.DirectorySeparatorChar}{serverId}{Path.DirectorySeparatorChar}{videoId}"));
        }

        public async Task RemoveOldVideosAsync(int days)
        {
            var files = Directory.GetFiles(_path);

            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTimeUtc < DateTime.UtcNow.AddDays(days))
                    fi.Delete();
            }
        }

        public async Task SaveToFileAsync(Guid videoId, string binary, Guid serverId)
        {
            Directory.CreateDirectory($"{_path}{Path.DirectorySeparatorChar}{serverId}");

            using (var file = File.Create($"{_path}{Path.DirectorySeparatorChar}{serverId}{Path.DirectorySeparatorChar}{videoId}"))
            {
                await file.WriteAsync(Convert.FromBase64String(binary));
            }
        }
    }
}
