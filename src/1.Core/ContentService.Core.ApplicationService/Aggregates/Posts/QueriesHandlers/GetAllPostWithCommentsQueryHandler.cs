using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
using ContentService.Core.Contracts.Aggregates.Posts.QueryRepositories;

using FluentResults;

using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

using Microsoft.Extensions.Logging;

namespace ContentService.Core.ApplicationService.Aggregates.Posts.QueriesHandlers;
public sealed class GetAllPostWithCommentsQueryHandler : IQueryHandler<GetAllPostWithCommentQuery, List<PostWithCommentsQueryResult>>
{
	private readonly IPostQueryRepository _postQueryRepository;
	private readonly ILogger<GetPostByIdQueryHandler> _logger;

	public GetAllPostWithCommentsQueryHandler(IPostQueryRepository postQueryRepository, ILogger<GetPostByIdQueryHandler> logger)
	{
		_postQueryRepository = postQueryRepository;
		_logger = logger;
	}
	public async Task<Result<List<PostWithCommentsQueryResult>>> Handle(GetAllPostWithCommentQuery request, CancellationToken cancellationToken)
	{
		Result<List<PostWithCommentsQueryResult>> result = new();
		var posts = await _postQueryRepository.ExecuteAsync(request, cancellationToken);
		result.WithValue(posts);
		return result;
	}
}
