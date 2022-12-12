using VideoMonitor.Enums;

namespace VideoMonitor.Resources
{
    public class RecyclerStatusResource
    {
        public RecyclerStatusResource(RecyclerStatus status)
        {
            switch(status) 
            {
                case RecyclerStatus.Running:
                    Status = "running";
                    break;
                case RecyclerStatus.NotRunning:
                default:
                    Status = "not running";
                    break;
            }
        }

        public string Status { get; }
    }
}
