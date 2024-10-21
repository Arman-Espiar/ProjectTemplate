using ContentService.Core.Contracts.Aggregates.Categories.CommandRepositories;
using ContentService.Core.Contracts.Aggregates.Categories.Commands;

using FluentResults;

using MDF.Contract.ApplicationServices.MediatorExtensions.CQRS;

using Microsoft.Extensions.Logging;

using Resources.Common.FormattedMessages;

namespace ContentService.Core.ApplicationService.Aggregates.Categories.CommandHandlers;
public class RemoveParentCategoryCommandHandler : ICommandHandler<RemoveParentCategoryCommand>
{
	private readonly ICategoryCommandRepository _categoryCommandRepository;
	private readonly ILogger<RemoveParentCategoryCommandHandler> _logger;

	public RemoveParentCategoryCommandHandler(ILogger<RemoveParentCategoryCommandHandler> logger, ICategoryCommandRepository categoryCommandRepository)
	{
		_logger = logger;
		_categoryCommandRepository = categoryCommandRepository;
	}

	public async Task<Result> Handle(RemoveParentCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = await _categoryCommandRepository.GetByAsync(request.CategoryId, cancellationToken);
		if (category is null)
		{
			return Result.Fail(ErrorMessages.NotFound(request.ToString()));
		}

		if (category.Result.IsSuccess)
		{
			category.RemoveAllParentsCategory();
			_categoryCommandRepository.UpdateBy(category);
			await _categoryCommandRepository.CommitAsync(cancellationToken);
		}
		return category.Result;
	}
}
