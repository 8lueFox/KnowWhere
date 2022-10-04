using KW.Application.Requests.RoadObjects;
using KW.Application.Requests.RoadObjects.Commands;
using KW.Application.Requests.RoadObjects.Queries;
using Microsoft.AspNetCore.Mvc;

namespace KW.Api.Controllers;

public class RoadObjectsController : BaseApiController
{
    [HttpGet]
    public async Task<RoadObjectsDto> GetAllAsync([FromQuery] GetAllRoadObjectsRequest request)
        => await Mediator.Send(request);

    [HttpGet("{id:guid}")]
    public async Task<RoadObjectDto> GetAsync(Guid id)
        => await Mediator.Send(new GetRoadObjectRequest(id));

    [HttpPost]
    public async Task<Guid> CreateAsync([FromQuery] CreateRoadObjectRequest request)
        => await Mediator.Send(request);

    [HttpDelete]
    public async Task<Guid> DeleteAsync([FromQuery] DeleteRoadObjectRequest request)
        => await Mediator.Send(request);

    [HttpPut]
    public async Task<Guid> UpdateAsync([FromQuery] UpdateRoadObjectRequest request)
        => await Mediator.Send(request);
}
