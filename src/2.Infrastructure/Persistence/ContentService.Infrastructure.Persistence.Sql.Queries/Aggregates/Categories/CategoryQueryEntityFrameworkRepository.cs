using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetCategoryById;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.ResultViewModel;
using ContentService.Core.Contracts.Aggregates.Categories.QueryRepositories;
using ContentService.Infrastructure.Persistence.Sql.Queries.Common;
using ContentService.Infrastructure.Persistence.Sql.Queries.Mapping;

using MDF.Framework.Infrastructure.Queries;

using Microsoft.EntityFrameworkCore;

namespace ContentService.Infrastructure.Persistence.Sql.Queries.Aggregates.Categories;
public class CategoryQueryEntityFrameworkRepository : BaseQueryRepository<ContentServiceQueryDbContext>, ICategoryQueryRepository
{

	public CategoryQueryEntityFrameworkRepository(ContentServiceQueryDbContext dbContext) : base(dbContext)
	{
	}

	public Task<List<CategoryQueryResult>> ExecuteAsync(GetAllCategoryQuery query, CancellationToken cancellationToken = default)
	{
		return DbContext.Categories.Select(c => new CategoryQueryResult
		{
			Id = c.Id,
			ParentCategoriesId = c.ParentCategoriesId,
			CategoryTitle = c.CategoryTitle,
			PostIds = c.PostIds
		}).ToListAsync(cancellationToken);
	}

	public async Task<List<CategoryQueryResult>> ExecuteAsync(GetAllSubCategoryQuery query, CancellationToken cancellationToken = default)
	{
		return DbContext.Categories
			.AsEnumerable() //کل دیتابیس روی حافظه بارگذاری میشود. سپس باقی دستورات روی آن اجرا میشود. این روش برای داده های خیلی کم مناسب میباشد
			.Where(c => c.ParentCategoriesId.Any(id => id == query.CategoryId))
			.ToCategoryQueryResult()
			.ToList();

	}

	public Task<CategoryQueryResult> ExecuteAsync(GetCategoryByIdQuery query, CancellationToken cancellationToken = default)
	{
		return DbContext.Categories
			.Where(c => c.Id == query.Id)
			.ToCategoryQueryResult()
			.FirstOrDefaultAsync(cancellationToken);
	}
}
