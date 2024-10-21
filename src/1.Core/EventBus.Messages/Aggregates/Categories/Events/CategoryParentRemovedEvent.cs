using MDF.SeedWork;

namespace EventBus.Messages.Aggregates.Categories.Events;

public record CategoryParentRemovedEvent(Guid Id, List<Guid> ParentCategoriesId) : IDomainEvent;