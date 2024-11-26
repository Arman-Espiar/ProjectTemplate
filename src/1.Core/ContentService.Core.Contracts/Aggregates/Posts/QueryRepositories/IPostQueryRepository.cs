using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostAndCommentById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;


namespace ContentService.Core.Contracts.Aggregates.Posts.QueryRepositories;
public interface IPostQueryRepository
{
	public Task<PostQueryResult> ExecuteAsync(GetPostByIdQuery query, CancellationToken cancellationToken = default);
	public Task<List<PostQueryResult>> ExecuteAsync(GetAllPostQuery query, CancellationToken cancellationToken = default);
	public Task<List<PostWithCommentsQueryResult>> ExecuteAsync(GetAllPostWithCommentQuery query, CancellationToken cancellationToken = default);
	public Task<PostWithCommentsQueryResult> ExecuteAsync(GetPostWithCommentsByIdQuery query, CancellationToken cancellationToken = default);
}
