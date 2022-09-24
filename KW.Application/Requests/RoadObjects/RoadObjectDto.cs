using KW.Application.Common.Interfaces;

namespace KW.Application.Requests.RoadObjects;

public class RoadObjectDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Colour { get; set; } 
}
