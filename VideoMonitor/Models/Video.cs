namespace VideoMonitor.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ServerId { get; set; }
    }
}
