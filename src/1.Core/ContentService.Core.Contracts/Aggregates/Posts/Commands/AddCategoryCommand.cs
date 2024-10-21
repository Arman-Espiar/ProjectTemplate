using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Commands;
public readonly record struct AddCategoryCommand : ICommand<Guid>
{
	public Guid PostId { get; init; }
	public Guid CategoryId { get; init; }
}
