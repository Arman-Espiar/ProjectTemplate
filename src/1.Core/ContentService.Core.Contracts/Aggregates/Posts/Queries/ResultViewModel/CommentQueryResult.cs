namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.ResultViewModel;
public class CommentQueryResult
{
	public Guid Id { get; set; }

	public Guid PostId { get; set; }

	public string Name { get; set; }

	public string Email { get; set; }

	public string CommentText { get; set; }
}
