using ContentService.Core.Contracts.Aggregates.Categories.CommandRepositories;
using ContentService.Core.Contracts.Aggregates.Categories.Commands;

using FluentResults;

using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

using Resources.Common.FormattedMessages;

namespace ContentService.Core.ApplicationService.Aggregates.Categories.CommandHandlers;
public class CategoryTitleChangeCommandHandler : ICommandHandler<CategoryTitleChangeCommand, Guid>
{
	private readonly ICategoryCommandRepository _categoryCommandRepository;

	public CategoryTitleChangeCommandHandler(ICategoryCommandRepository categoryCommandRepository)
	{

		_categoryCommandRepository = categoryCommandRepository;
	}

	public async Task<Result<Guid>> Handle(CategoryTitleChangeCommand request, CancellationToken cancellationToken)
	{
		var category = await _categoryCommandRepository.GetByAsync(request.Id, cancellationToken);
		if (category is null)
		{
			return Result.Fail(ErrorMessages.NotFound(request.ToString()));
		}
		category.ChangeCategoryTitle(request.Title);

		if (category.Result.IsFailed)
		{
			return category.Result;
		}
		_categoryCommandRepository.UpdateBy(category);
		await _categoryCommandRepository.CommitAsync(cancellationToken);
		return category.Id;
	}
}
