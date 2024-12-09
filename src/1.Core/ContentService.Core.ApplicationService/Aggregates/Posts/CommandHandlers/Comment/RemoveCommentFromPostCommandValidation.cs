using ContentService.Core.Contracts.Aggregates.Posts.Commands.Comment;
using ContentService.Core.Domain.Aggregates.Posts.ValueObjects;

using FluentValidation;

namespace ContentService.Core.ApplicationService.Aggregates.Posts.CommandHandlers.Comment;
public class RemoveCommentFromPostCommandValidation : AbstractValidator<RemoveCommentFromPostCommand>
{
	public RemoveCommentFromPostCommandValidation()
	{
		//نامگذاری ها در این پروژه دقیق نیست
		RuleFor(c => c.DisplayName)
			.NotNull()
			.MinimumLength(DisplayName.Minimum)
			.MaximumLength(DisplayName.Maximum);
		RuleFor(c => c.Email)
			.NotNull()
			.Matches(Email.EmailPattern);
		RuleFor(c => c.CommentText)
			.NotNull()
			.MinimumLength(CommentText.Minimum)
			.MaximumLength(CommentText.Maximum);
	}
}
