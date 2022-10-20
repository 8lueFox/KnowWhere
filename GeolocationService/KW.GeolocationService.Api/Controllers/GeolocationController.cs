using KW.GeolocationService.Application;
using KW.GeolocationService.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KW.GeolocationService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<RouteDto>> GetGeocoding([FromBody] GetGeocode request)
        {
            var response = await _hooperService.GetGeocoding(request);

            return Ok(response);
        }
    }
}
