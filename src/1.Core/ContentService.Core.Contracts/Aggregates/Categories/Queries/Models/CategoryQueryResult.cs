namespace ContentService.Core.Contracts.Aggregates.Categories.Queries.Models;

public readonly record struct CategoryQueryResult
{
	public Guid Id { get; init; }
	public string CategoryTitle { get; init; }
	public List<Guid> ParentCategoriesId { get; init; }
	public List<Guid> PostIds { get; init; }
}