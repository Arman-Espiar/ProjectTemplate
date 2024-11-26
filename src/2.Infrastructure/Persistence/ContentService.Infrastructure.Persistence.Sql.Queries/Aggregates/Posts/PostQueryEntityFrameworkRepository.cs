using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostAndCommentById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
using ContentService.Core.Contracts.Aggregates.Posts.QueryRepositories;
using ContentService.Infrastructure.Persistence.Sql.Queries.Common;
using ContentService.Infrastructure.Persistence.Sql.Queries.Mapping;

using MDF.Framework.Infrastructure.Queries;

using Microsoft.EntityFrameworkCore;

namespace ContentService.Infrastructure.Persistence.Sql.Queries.Aggregates.Posts;
public class PostQueryEntityFrameworkRepository : BaseQueryRepository<ContentServiceQueryDbContext>, IPostQueryRepository
{

	public PostQueryEntityFrameworkRepository(ContentServiceQueryDbContext dbContext) : base(dbContext)
	{
	}

	public Task<PostQueryResult> ExecuteAsync(GetPostByIdQuery query, CancellationToken cancellationToken = default)
	{
		//manual mapping
		return DbContext.Posts.Select(c => new PostQueryResult()
		{
			Id = c.Id,
			CategoryIds = c.CategoryIds,
			Title = c.Title,
			Description = c.Description,
			Text = c.Text
		}).FirstOrDefaultAsync(c => c.Id.Equals(query.PostId), cancellationToken);
	}

	public Task<List<PostQueryResult>> ExecuteAsync(GetAllPostQuery query, CancellationToken cancellationToken = default)
	{
		//manual mapping
		return DbContext.Posts.ToPostQueryResult().ToListAsync(cancellationToken);
	}

	public Task<List<PostWithCommentsQueryResult>> ExecuteAsync(GetAllPostWithCommentQuery query, CancellationToken cancellationToken = default)
	{
		return DbContext.Posts.Include(p => p.Comments)
		.ToPostWithCommentsQueryResult()
			.ToListAsync(cancellationToken);
	}

	public async Task<PostWithCommentsQueryResult> ExecuteAsync(GetPostWithCommentsByIdQuery query, CancellationToken cancellationToken = default)
	{
		var post = await DbContext.Posts.Include(p => p.Comments).FirstOrDefaultAsync(p => p.Id == query.PostId, cancellationToken);

		return post.ToPostWithCommentsQueryResult();
	}
}