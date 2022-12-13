namespace VideoMonitor.Repository
{
    public class VideoFileRepository : IVideoFileRepository
    {
        private string _path = $".{Path.DirectorySeparatorChar}videos";

        public async Task DeleteVideoFileAsync(Guid videoId, Guid serverId)
        {
            FileInfo fi = new FileInfo($"{_path}{Path.DirectorySeparatorChar}{serverId}{Path.DirectorySeparatorChar}{videoId}");
            fi.Delete();
        }

        public async Task<string> GetVideoBinaryAsync(Guid videoId, Guid serverId)
        {
            return Convert.ToBase64String(await File.ReadAllBytesAsync($"{_path}{Path.DirectorySeparatorChar}{serverId}{Path.DirectorySeparatorChar}{videoId}"));
        }

        public async Task RemoveOldVideosAsync(int days)
        {
            var servers = Directory.GetDirectories(_path);

            foreach (var server in servers)
            {
                var videos = Directory.GetFiles(server);

                foreach (var video in videos)
                {
                    FileInfo fi = new FileInfo(video);
                    if (fi.CreationTimeUtc < DateTime.UtcNow.AddDays(days))
                        fi.Delete();
                }
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
