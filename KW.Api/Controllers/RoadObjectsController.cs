using FSH.WebApi.Host.Controllers;
using KW.Application.Requests.RoadObjects;
using KW.Application.Requests.RoadObjects.Queries;
using Microsoft.AspNetCore.Mvc;

namespace KW.Api.Controllers;

public class RoadObjectsController : BaseApiController
{
    [HttpGet("{id:guid}")]
    public async Task<RoadObjectDto> GetAsync(Guid id)//[FromQuery] GetRoadObjectRequest request)
    {
        return await Mediator.Send(new GetRoadObjectRequest(id));
    }
}
