using KW.Domain.ValueObjects;

namespace KW.Domain.Entities;

public class RoadObject : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public Colour Colour { get; private set; }

    public RoadObject(string name, Colour colour)
    {
        Name = name;
        Colour = colour;
    }

    public RoadObject(string name, string colour)
    {
        Name = name;
        Colour = Colour.From(colour);
    }

    public RoadObject(string name, object colour)
    {
        Name = name;
        //Colour = Colour.From(colour);
    }

    public RoadObject()
    {

    }

    public RoadObject Update(string? name, string? colour)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (colour is not null && Colour.ToString().Equals(colour) is not true) Colour = Colour.From(colour);
        return this;
    }
}
