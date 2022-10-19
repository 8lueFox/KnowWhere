using KW.GeolocationService.Application;
using KW.GeolocationService.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KW.GeolocationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IHooperService _hooperService;

        public GeolocationController(IHooperService hooperService)
        {
            _hooperService = hooperService;
        }

        [HttpPost]
        public async Task<ActionResult<RouteDto>> GetRoute([FromBody] GetRouteRequest request)
        {
            var response = await _hooperService.GetRoute(request);

            return Ok("Sended");
        }
    }
}
