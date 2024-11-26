namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
public record PostQueryResult
{
	public Guid Id { get; init; }
	public List<Guid?> CategoryIds { get; init; }
	public required string Title { get; init; }
	public required string Description { get; init; }
	public required string Text { get; init; }

}