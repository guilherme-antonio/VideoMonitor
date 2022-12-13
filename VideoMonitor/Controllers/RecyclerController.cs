using Microsoft.AspNetCore.Http.HttpResults;
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
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Accepted>> ProcessAsync(int days)
        {
            try
            {
                await _recyclerService.ProcessAsync(days);
                return TypedResults.Accepted(Url.Action(nameof(GetStatusAsync)) ?? "/status");
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }

        [HttpGet]
        [Route("status")]
        public async Task<Results<BadRequest, Ok<RecyclerStatusResource>>> GetStatusAsync()
        {
            try
            {
                var status = await _recyclerService.GetStatusAsync();
                return TypedResults.Ok(new RecyclerStatusResource(status));
            }
            catch (Exception)
            {
                return TypedResults.BadRequest();
            }
            
        }
    }
}
