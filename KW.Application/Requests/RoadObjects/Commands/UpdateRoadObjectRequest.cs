using FluentValidation;

namespace KW.Application.Requests.RoadObjects.Commands;

public record UpdateRoadObjectRequest(Guid Id, string Name, string Colour) : IRequest<Guid>;

public class UpdateRoadObjectRequestValidator : AbstractValidator<UpdateRoadObjectRequest>
{
    public UpdateRoadObjectRequestValidator(IRepository<RoadObject> repository)//, IStringLocalizer<UpdateRoadObjectRequest> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (roadObject, name, ct) =>
                    await repository.FirstOrDefaultAsync(new RoadObjectByNameSpec(name), ct)
                        is not RoadObject existingObject || existingObject.Id == roadObject.Id)
                ;//.WithMessage((_, name) => T[$"RoadObject {name} already exists."]);
    }
}

public class UpdateRoadObjectRequestHandler : IRequestHandler<UpdateRoadObjectRequest, Guid>
{
    private readonly IRepository<RoadObject> _repository;
    private readonly IStringLocalizer _t;

    public UpdateRoadObjectRequestHandler(IRepository<RoadObject> repository)//, IStringLocalizer t)
        => (_repository) = (repository);

    public async Task<Guid> Handle(UpdateRoadObjectRequest request, CancellationToken cancellationToken)
    {
        var roadObject = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = roadObject ?? throw new NotFoundException("");// throw new NotFoundException(_t[$"Brand {request.Id} not found."]);

        roadObject.Update(request.Name, request.Colour);

        await _repository.UpdateAsync(roadObject, cancellationToken);

        return request.Id;
    }
}
