using KW.Domain.ValueObjects;

namespace KW.Domain.Entities;

public class RoadObjectReport : AuditableEntity, IAggregateRoot
{
    public int Confirmation { get; private set; } = 5;
    public Localization Localization { get; private set; }

    public Guid RoadObjectId { get; private set; }
    public virtual RoadObject RoadObject { get; private set; } = default!;

    public RoadObjectReport(Localization localization)
    {
        Localization = localization;
    }

    public RoadObjectReport()
    {
    }

    public RoadObjectReport Update(int? confirmation, string? localizationCode, Guid? roadObjectId)
    {
        if (confirmation is not null) Confirmation = (int)confirmation;
        if (localizationCode is not null && Localization.Equals(localizationCode) is not true) Localization = Localization.From(localizationCode);
        if (roadObjectId is not null && roadObjectId.Value != Guid.Empty && !RoadObjectId.Equals(roadObjectId.Value)) RoadObjectId = roadObjectId.Value;
        return this;
    }
}
