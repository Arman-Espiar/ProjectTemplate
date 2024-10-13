using Framework.Contract.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Categories.Commands;
public readonly record struct RemoveCategoryCommand : ICommand
{
	public Guid Id { get; init; }
}
