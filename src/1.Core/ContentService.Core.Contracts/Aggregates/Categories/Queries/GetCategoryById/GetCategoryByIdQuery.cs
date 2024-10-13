using ContentService.Core.Contracts.Aggregates.Categories.Queries.Models;
using Framework.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQuery : IQuery<CategoryQueryDto>
{
    public Guid Id { get; set; }
}
