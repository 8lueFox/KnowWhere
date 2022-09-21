using KW.Shared.Events;

namespace KW.Domain.Common.Contracts;

public abstract class DomainEvent : IEvent
{
    public DateTime TriggeredOn { get; protected set; } = DateTime.UtcNow;
}