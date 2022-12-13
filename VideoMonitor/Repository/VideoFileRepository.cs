namespace VideoMonitor.Repository
{
    public class VideoFileRepository : IVideoFileRepository
    {
        private string _path = $".{Path.DirectorySeparatorChar}videos";

        public async Task<string> GetVideoBinaryAsync(Guid videoId)
        {
            return Convert.ToBase64String(await File.ReadAllBytesAsync($"{_path}{Path.DirectorySeparatorChar}{videoId}"));
        }

        public async Task RemoveOldVideosAsync(int days)
        {
            Thread.Sleep(20000);
            var files = Directory.GetFiles(_path);

            foreach (var file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.CreationTimeUtc < DateTime.UtcNow.AddDays(days))
                    fi.Delete();
            }
        }

        public async Task SaveToFileAsync(Guid videoId, string binary)
        {
            Directory.CreateDirectory(_path);

            using (var file = File.Create($"{_path}{Path.DirectorySeparatorChar}{videoId}"))
            {
                await file.WriteAsync(Convert.FromBase64String(binary));
            }
        }
    }
}
