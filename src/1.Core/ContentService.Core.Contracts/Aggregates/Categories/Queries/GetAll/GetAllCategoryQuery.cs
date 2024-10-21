using ContentService.Core.Contracts.Aggregates.Categories.Queries.Models;

using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Categories.Queries.GetAll;
public class GetAllCategoryQuery : IQuery<List<CategoryQueryDto>>
{
}