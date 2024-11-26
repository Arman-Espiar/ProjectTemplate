using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
using ContentService.Core.Contracts.Aggregates.Posts.QueryRepositories;

using FluentResults;

using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;
using MDF.Resources.Common;
using MDF.Resources.Common.FormattedMessages;

using Microsoft.Extensions.Logging;

namespace ContentService.Core.ApplicationService.Aggregates.Posts.QueriesHandlers;
public sealed class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostQueryResult>
{
	private readonly IPostQueryRepository _postQueryRepository;
	private readonly ILogger<GetPostByIdQueryHandler> _logger;

	public GetPostByIdQueryHandler(IPostQueryRepository postQueryRepository, ILogger<GetPostByIdQueryHandler> logger)
	{
		_postQueryRepository = postQueryRepository;
		_logger = logger;
	}
	public async Task<Result<PostQueryResult>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
	{
		var result = new Result<PostQueryResult>();
		var postFound = await _postQueryRepository.ExecuteAsync(request);
		if (postFound is null)
		{
			result.WithError(ErrorMessages.NotFound(DataDictionary.Post + "  id: " + request.PostId));
			return result;
		}
		result.WithValue(postFound);
		return result;
	}
}
