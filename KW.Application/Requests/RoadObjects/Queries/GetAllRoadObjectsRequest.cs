namespace KW.Application.Requests.RoadObjects.Queries;

public record GetAllRoadObjectsRequest() : IRequest<RoadObjectsDto>;

public class GetAllRoadObjectsRequestHandler : IRequestHandler<GetAllRoadObjectsRequest, RoadObjectsDto>
{
    private readonly IRepository<RoadObject> _repository;
    //private readonly IStringLocalizer _t;

    public GetAllRoadObjectsRequestHandler(IRepository<RoadObject> repository)//, IStringLocalizer<GetAllRoadObjectsRequestHandler> localizer)
        => (_repository) = (repository);

    public async Task<RoadObjectsDto> Handle(GetAllRoadObjectsRequest request, CancellationToken cancellationToken)
    {
        var objects = await _repository.ListAsync(cancellationToken);
        return new RoadObjectsDto { RoadObjects = objects.ToList() };
    }
}