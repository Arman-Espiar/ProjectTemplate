using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetCategoryById;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.Models;


namespace ContentService.Core.Contracts.Aggregates.Categories.QueryRepositories;
public interface ICategoryQueryRepository
{
	public Task<List<CategoryQueryResult>> ExecuteAsync(GetAllCategoryQuery query, CancellationToken cancellationToken = default);
	public Task<List<CategoryQueryResult>> ExecuteAsync(GetAllSubCategoryQuery query, CancellationToken cancellationToken = default);
	public Task<CategoryQueryResult> ExecuteAsync(GetCategoryByIdQuery query, CancellationToken cancellationToken = default);
}
