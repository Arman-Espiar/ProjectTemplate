using ContentService.Core.Contracts.Aggregates.Posts.Queries.ResultViewModel;

using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostAndCommentById;
public record GetPostWithCommentsByIdQuery : IQuery<PostWithCommentsQueryResult>
{
	public Guid PostId { get; init; }
}
