using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Categories.Commands;
public class RemoveParentCategoryCommand : ICommand
{
	public Guid CategoryId { get; init; }
}
