using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
using ContentService.Infrastructure.Persistence.Sql.Queries.QueryModels;

namespace ContentService.Infrastructure.Persistence.Sql.Queries.Mapping;
public static class PostAndCommentsMapping
{
	public static IQueryable<PostWithCommentsQueryResult> ToPostWithCommentsQueryResult(this IQueryable<PostQuery> postQueries)
	{
		return postQueries.Select(pqs => new PostWithCommentsQueryResult
		{
			Comments = pqs.Comments.ToCommentQueryResult(),
			Description = pqs.Description,
			Text = pqs.Text,
			Title = pqs.Title,
			CategoryIds = pqs.CategoryIds,
			Id = pqs.Id
		});
	}

	public static IQueryable<PostQueryResult> ToPostQueryResult(this IQueryable<PostQuery> postQueries)
	{
		return postQueries.Select(pqs => new PostQueryResult
		{
			Id = pqs.Id,
			CategoryIds = pqs.CategoryIds,
			Title = pqs.Title,
			Description = pqs.Description,
			Text = pqs.Text
		});
	}

	public static PostWithCommentsQueryResult ToPostWithCommentsQueryResult(this PostQuery? postQuery)
	{
		if (postQuery is null) return new PostWithCommentsQueryResult
		{
			CategoryIds = [],
			Id = new Guid(),
			Title = string.Empty,
			Description = string.Empty,
			Text = string.Empty,
			Comments = []
		};

		return new PostWithCommentsQueryResult
		{
			Id = postQuery.Id,
			Title = postQuery.Title,
			Description = postQuery.Description,
			Text = postQuery.Text,
			CategoryIds = postQuery.CategoryIds,
			Comments = postQuery.Comments.ToCommentQueryResult()
		};
	}
	public static CommentQueryResult ToCommentQueryResult(this CommentQuery commentQuery)
	{
		return new CommentQueryResult
		{
			Id = commentQuery.Id,
			PostId = commentQuery.PostId,
			CommentText = commentQuery.CommentText,
			Email = commentQuery.Email,
			Name = commentQuery.Name
		};
	}

	private static List<CommentQueryResult?> ToCommentQueryResult(this ICollection<CommentQuery?> commentQueries)
	{
		return commentQueries.Select(commentQuery => new CommentQueryResult
		{
			Id = commentQuery.Id,
			PostId = commentQuery.PostId,
			CommentText = commentQuery.CommentText,
			Email = commentQuery.Email,
			Name = commentQuery.Name
		}).ToList();
	}
}