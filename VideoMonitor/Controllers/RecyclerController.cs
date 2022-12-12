using Microsoft.AspNetCore.Mvc;
using VideoMonitor.Resources;
using VideoMonitor.Services;

namespace VideoMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecyclerController : ControllerBase
    {
        private readonly IRecyclerService _recyclerService;

        public RecyclerController(IRecyclerService recyclerService)
        {
            _recyclerService = recyclerService;
        }

        [HttpPost]
        [Route("process/{days}")]
        public async Task ProcessAsync(int days)
        {
            await _recyclerService.ProcessAsync(days);
        }

        [HttpGet]
        [Route("status")]
        public async Task<RecyclerStatusResource> GetStatusAsync()
        {
            var status = await _recyclerService.GetStatusAsync();
            return new RecyclerStatusResource(status);
        }
    }
}
