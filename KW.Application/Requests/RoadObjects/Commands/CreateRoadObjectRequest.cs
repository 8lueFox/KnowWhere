using FluentValidation;
using KW.Domain.ValueObjects;

namespace KW.Application.Requests.RoadObjects.Commands;

public record CreateRoadObjectRequest(string Name, string Colour) : IRequest<Guid>;

public class RoadObjectByNameSpec : Specification<RoadObject>, ISingleResultSpecification
{
    public RoadObjectByNameSpec(string name) =>
        Query.Where(b => b.Name == name);
}

public class CreateRoadObjectRequestValidator : AbstractValidator<CreateRoadObjectRequest>
{
    public CreateRoadObjectRequestValidator(IReadRepository<RoadObject> repository, IStringLocalizer<CreateRoadObjectRequest> T)
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MaximumLength(75)
            .MustAsync(async (name, ct) => await repository.FirstOrDefaultAsync(new RoadObjectByNameSpec(name), ct) is null)
                .WithMessage((_, name) => T[$"RoadObject {name} already exists."]);

        RuleFor(p => p.Colour)
            .NotEmpty()
            .Must((colourCode) => Colour.SupportedColours.Contains(Colour.From(colourCode)))
                .WithMessage((_, colourCode) => T[$"RoadObject cannot be declared with colour {colourCode}, becouse this colour is not supported"]);
    }
}

public class CreateRoadObjectRequestHandler : IRequestHandler<CreateRoadObjectRequest, Guid>
{
    private readonly IRepositoryWithEvents<RoadObject> _repository;

    public CreateRoadObjectRequestHandler(IRepositoryWithEvents<RoadObject> repository) 
        => _repository = repository;

    public async Task<Guid> Handle(CreateRoadObjectRequest request, CancellationToken cancellationToken)
    {
        var roadObject = new RoadObject(request.Name, request.Colour);

        await _repository.AddAsync(roadObject, cancellationToken);

        return roadObject.Id;
    }
}