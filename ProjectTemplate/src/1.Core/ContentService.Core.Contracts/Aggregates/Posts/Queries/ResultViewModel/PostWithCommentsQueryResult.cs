namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.ResultViewModel;
public record PostWithCommentsQueryResult
{
	public Guid Id { get; init; }
	public List<Guid?> CategoryIds { get; init; }
	public required string Title { get; init; }
	public required string Description { get; init; }
	public required string Text { get; init; }
	public required List<CommentQueryResult?> Comments { get; init; }
}