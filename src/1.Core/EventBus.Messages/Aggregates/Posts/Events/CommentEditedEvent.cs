using MDF.SeedWork;

namespace EventBus.Messages.Aggregates.Posts.Events;
public record CommentEditedEvent(
	Guid PostId,
	Guid CommentId,
	string DisplayName,
	string Email,
	string CommentText)
	: IDomainEvent;
