using ContentService.Core.Contracts.Aggregates.Posts.CommandRepositories;
using ContentService.Core.Contracts.Aggregates.Posts.Commands.Comment;
using ContentService.Core.Domain.Aggregates.Posts;

using FluentResults;

using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;
using MDF.Resources.Common.FormattedMessages;

using Microsoft.Extensions.Logging;

namespace ContentService.Core.ApplicationService.Aggregates.Posts.CommandHandlers.Comment;
public sealed class AddCommentToPostCommandHandlers : ICommandHandler<AddCommentToPostCommand, Guid>
{
	private readonly IPostCommandRepository _postRepository;
	private readonly ILogger<AddCommentToPostCommandHandlers> _logger;
	public AddCommentToPostCommandHandlers(IPostCommandRepository postRepository, ILogger<AddCommentToPostCommandHandlers> logger)
	{
		_postRepository = postRepository;
		_logger = logger;
	}

	public async Task<Result<Guid>> Handle(AddCommentToPostCommand request, CancellationToken cancellationToken)
	{
		var post = await _postRepository.GetGraphByAsync(request.PostId, cancellationToken);
		if (post is not null)
		{
			post.AddComment(request.DisplayName, request.Email, request.CommentText);

			if (post.Result.IsSuccess)
			{
				_postRepository.UpdateBy(post);
				await _postRepository.CommitAsync(cancellationToken);
				return post.Id;
			}
			return post.Result;
		}
		return Result.Fail(ErrorMessages.NotFound(request.ToString()));
	}

}
