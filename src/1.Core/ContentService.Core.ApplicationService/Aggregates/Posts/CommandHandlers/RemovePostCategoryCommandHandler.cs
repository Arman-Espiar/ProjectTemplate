using ContentService.Core.Contracts.Aggregates.Posts.CommandRepositories;
using ContentService.Core.Contracts.Aggregates.Posts.Commands.Comment;

using FluentResults;

using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

using Microsoft.Extensions.Logging;

using Resources.Common.FormattedMessages;

namespace ContentService.Core.ApplicationService.Aggregates.Posts.CommandHandlers;
public class RemovePostCategoryCommandHandler : ICommandHandler<RemovePostCategoryCommand>
{
	private readonly IPostCommandRepository _postCommandRepository;
	private readonly ILogger<RemovePostCategoryCommandHandler> _logger;

	public RemovePostCategoryCommandHandler(IPostCommandRepository postCommandRepository, ILogger<RemovePostCategoryCommandHandler> logger)
	{
		_postCommandRepository = postCommandRepository;
		_logger = logger;
	}

	public async Task<Result> Handle(RemovePostCategoryCommand request, CancellationToken cancellationToken)
	{
		var post = await _postCommandRepository.GetByAsync(request.PostId, cancellationToken);
		if (post is null)
		{
			return Result.Fail(ErrorMessages.NotFound(request.ToString()));
		}
		post.RemoveCategory(request.CategoryId);

		if (post.Result.IsSuccess)
		{
			//_postCommandRepository.UpdateBy(post.Value);
			await _postCommandRepository.CommitAsync(cancellationToken);
			return post.Result;
		}
		return post.Result.WithError(ErrorMessages.UnexpectedError);
	}
}
