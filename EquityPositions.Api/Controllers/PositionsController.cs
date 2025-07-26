using Microsoft.AspNetCore.Mvc;
using EquityPositions.Api.Services;

namespace EquityPositions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly PositionService _service;
        public PositionsController(PositionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPositions()
        {
            var result = await _service.GetPositionsAsync();
            return Ok(result);
        }
    }
}