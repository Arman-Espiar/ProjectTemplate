using ContentService.Core.Contracts.Aggregates.Posts.Queries.Models;
using Framework.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostById;
public record GetPostByIdQuery : IQuery<PostQueryDto>
{
	public Guid PostId { get; init; }
}
