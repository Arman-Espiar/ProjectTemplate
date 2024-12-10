using ContentService.Core.Contracts.Aggregates.Posts.Queries.ResultViewModel;

using MDF.Framework.LayersContracts;
using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostById;
public record GetPostByIdQuery : IQuery<PostQueryResult>
{
	public Guid PostId { get; init; }
}
