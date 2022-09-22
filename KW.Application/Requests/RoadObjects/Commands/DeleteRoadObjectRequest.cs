using KW.Application.Requests.RoadObjectsReports;

namespace KW.Application.Requests.RoadObjects.Commands;

public record DeleteRoadObjectRequest(Guid Id) : IRequest<Guid>;

public class DeleteRoadObjectRequestHandler : IRequestHandler<DeleteRoadObjectRequest, Guid>
{
    private readonly IRepositoryWithEvents<RoadObject> _roadObjectRepo;
    private readonly IReadRepository<RoadObjectReport> _reportRepo;
    private readonly IStringLocalizer _t;

    public DeleteRoadObjectRequestHandler(IRepositoryWithEvents<RoadObject> roadObjectRepo,
        IReadRepository<RoadObjectReport> reportRepo,
        IStringLocalizer<DeleteRoadObjectRequestHandler> localizer)
        => (_roadObjectRepo, _reportRepo, _t) = (roadObjectRepo, reportRepo, localizer);

    public async Task<Guid> Handle(DeleteRoadObjectRequest request, CancellationToken cancellationToken)
    {
        if(await _reportRepo.AnyAsync(new ReportsByRoadObjectSpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_t["RoadObject cannot be deleted as it's being used."]);
        }

        var roadObject = await _roadObjectRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = roadObject ?? throw new NotFoundException(_t[$"Brand {request.Id} not found."]);

        await _roadObjectRepo.DeleteAsync(roadObject, cancellationToken);

        return request.Id;
    }
}