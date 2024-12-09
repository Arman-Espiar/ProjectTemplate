using ContentService.Core.Contracts.Aggregates.Categories.Queries.ResultViewModel;
using ContentService.Infrastructure.Persistence.Sql.Queries.Aggregates.Categories.QueryModels;


namespace ContentService.Infrastructure.Persistence.Sql.Queries.Mapping;
public static class CategoryQueryMapping
{
	public static IQueryable<CategoryQueryResult> ToCategoryQueryResult(this IQueryable<CategoryQuery> categories)
	{
		return categories.Select(c => new CategoryQueryResult
		{
			Id = c.Id,
			ParentCategoriesId = c.ParentCategoriesId,
			CategoryTitle = c.CategoryTitle,
			PostIds = c.PostIds
		});
	}
	public static IEnumerable<CategoryQueryResult> ToCategoryQueryResult(this IEnumerable<CategoryQuery> categories)
	{
		return categories.Select(c => new CategoryQueryResult
		{
			Id = c.Id,
			ParentCategoriesId = c.ParentCategoriesId,
			CategoryTitle = c.CategoryTitle,
			PostIds = c.PostIds
		});
	}
}
