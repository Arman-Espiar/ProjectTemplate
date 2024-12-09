using ContentService.Core.Contracts.Aggregates.Categories.Queries.ResultViewModel;

using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQuery : IQuery<CategoryQueryResult>
{
	public Guid Id { get; set; }
}
