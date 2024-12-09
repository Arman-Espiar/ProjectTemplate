using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Commands.Comment;
public class RemoveCommentFromPostCommand(Guid postId, string displayName, string email, string commentText) : BaseCommand
{
	// or using valueObject instead of string
	public Guid PostId { get; } = postId;
	public string DisplayName { get; } = displayName;
	public string Email { get; } = email;
	public string CommentText { get; } = commentText;
}
