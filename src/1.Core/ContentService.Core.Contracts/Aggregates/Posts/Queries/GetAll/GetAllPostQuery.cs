using ContentService.Core.Contracts.Aggregates.Posts.Queries.ResultViewModel;

using Gridify;

using MDF.Framework.LayersContracts;
using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.GetAll;
public record GetAllPostQuery : BaseQueryFiltering, IQuery<List<PostQueryResult>>
{
}
