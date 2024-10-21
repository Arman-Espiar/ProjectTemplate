using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Categories.Commands;
public record CreateCategoryCommand : ICommand<Guid>
{
	public required string Title { get; init; }
}
