using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
using Framework.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostAndCommentById;
public record GetPostWithCommentsByIdQuery : IQuery<PostWithCommentsQueryDto>
{
	public Guid PostId { get; init; }
}
