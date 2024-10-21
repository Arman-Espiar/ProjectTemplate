using MDF.SeedWork;

namespace EventBus.Messages.Aggregates.Categories.Events;

public record CategoryTitleChangedEvent(Guid Id, string? TitleValue) : IDomainEvent;