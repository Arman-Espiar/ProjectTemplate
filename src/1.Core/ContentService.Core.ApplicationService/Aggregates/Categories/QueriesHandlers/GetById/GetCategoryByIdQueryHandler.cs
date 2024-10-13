using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetCategoryById;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.Models;
using ContentService.Core.Contracts.Aggregates.Categories.QueryRepositories;

using FluentResults;

using Framework.Contract.ApplicationServices.MediatorExtensions.CQRS;

using Microsoft.Extensions.Logging;

namespace ContentService.Core.ApplicationService.Aggregates.Categories.QueriesHandlers.GetById;
public class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryQueryDto>
{
	private readonly ICategoryQueryRepository _repository;
	private readonly ILogger<GetCategoryByIdQueryHandler> _logger;

	public GetCategoryByIdQueryHandler(ILogger<GetCategoryByIdQueryHandler> logger, ICategoryQueryRepository repository)
	{
		_logger = logger;
		_repository = repository;
	}

	public async Task<Result<CategoryQueryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
	{
		var category = await _repository.ExecuteAsync(request, cancellationToken);
		return Result.Ok(category);
	}
}
