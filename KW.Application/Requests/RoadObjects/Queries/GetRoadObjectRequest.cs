namespace KW.Application.Requests.RoadObjects.Queries;

public record GetRoadObjectRequest(Guid Id) : IRequest<RoadObjectDto>;

public class RoadObjectById : Specification<RoadObject, RoadObjectDto>, ISingleResultSpecification
{
    public RoadObjectById(Guid id)
    {
        Query.Where(p => p.Id == id);
        Query.AsNoTracking();
    }
}

public class GetBrandRequestHandler : IRequestHandler<GetRoadObjectRequest, RoadObjectDto>
{
    private readonly IRepository<RoadObject> _repository;
    //private readonly IStringLocalizer _t;

    public GetBrandRequestHandler(IRepository<RoadObject> repository)//, IStringLocalizer<GetRoadObjectRequest> localizer)
        => (_repository) = (repository);

    public async Task<RoadObjectDto> Handle(GetRoadObjectRequest request, CancellationToken cancellationToken)
        => await _repository.FirstOrDefaultAsync(
            (ISpecification<RoadObject, RoadObjectDto>)new RoadObjectById(request.Id), cancellationToken)
        ?? throw new NotFoundException($"Brand {request.Id} Not Found.");// throw new NotFoundException(_t[$"Brand {request.Id} not found."]);
}