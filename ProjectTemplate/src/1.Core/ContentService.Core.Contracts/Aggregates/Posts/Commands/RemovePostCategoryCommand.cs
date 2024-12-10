using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Commands;
public readonly record struct RemovePostCategoryCommand : ICommand
{
	public Guid PostId { get; init; }
	public Guid CategoryId { get; init; }
}
