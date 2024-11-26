using ContentService.Core.Contracts.Aggregates.Categories.Commands;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.GetCategoryById;
using ContentService.Core.Contracts.Aggregates.Categories.Queries.Models;
using ContentService.Endpoints.API.Controllers;

using FluentResults;

using MDF.Framework.Extensions.Results;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Moq;

namespace ContentService.Endpoints.API.Tests.Unit.Controllers;
public class CategoryControllerTests
{
	private readonly Mock<IMediator> _mediatorMock;

	private readonly CategoryController _categoryController;

	public CategoryControllerTests()
	{
		_mediatorMock = new Mock<IMediator>();
		_categoryController = new CategoryController(_mediatorMock.Object);
	}

	[Fact]
	public async Task ShouldBe_ReturnsListOfCategories_When_GetAllCategoryAsync()
	{
		// Arrange
		var expectedCategories = new List<CategoryQueryResult>
							{
								new CategoryQueryResult { Id = Guid.CreateVersion7(), CategoryTitle = "Category 1" },
								new CategoryQueryResult { Id = Guid.CreateVersion7(), CategoryTitle = "Category 2" }
							};

		_mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCategoryQuery>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(expectedCategories);

		// Act
		var result = await _categoryController.GetAllCategoryAsync();

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		var actualCategories = Assert.IsType<CustomResult<List<CategoryQueryResult>>>(okResult.Value);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
		Assert.Equal(expectedCategories, actualCategories.Value);
	}

	[Fact]
	public async Task ShouldBe_ReturnsCategory_When_GetPostAsync()
	{
		// Arrange
		var categoryId = Guid.CreateVersion7();
		var expectedCategory = new CategoryQueryResult { Id = categoryId, CategoryTitle = "Category 1" };

		_mediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(expectedCategory);

		// Act
		var result = await _categoryController.GetCategoryAsync(new GetCategoryByIdQuery { Id = categoryId });

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		var actualCategory = Assert.IsType<CustomResult<CategoryQueryResult>>(okResult.Value);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
		Assert.Equal(expectedCategory, actualCategory.Value);
	}

	[Fact]
	public async Task ShouldBe_ReturnsListOfSubCategories_When_GetCategoryIdAsync()
	{
		// Arrange
		var categoryId = Guid.CreateVersion7();
		var expectedSubCategories = new List<CategoryQueryResult>
							{
								new CategoryQueryResult { Id = Guid.CreateVersion7(), CategoryTitle = "Subcategory 1" },
								new CategoryQueryResult { Id = Guid.CreateVersion7(), CategoryTitle = "Subcategory 2" }
							};

		_mediatorMock.Setup(m => m.Send(It.IsAny<GetAllSubCategoryQuery>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(expectedSubCategories);

		// Act
		var result = await _categoryController.GetSubCategoriesAsync(new GetAllSubCategoryQuery { CategoryId = categoryId });

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		var actualSubCategories = Assert.IsType<CustomResult<List<CategoryQueryResult>>>(okResult.Value);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
		Assert.Equal(expectedSubCategories, actualSubCategories.Value);
	}

	[Fact]
	public async Task ShouldBe_ReturnsCreatedCategoryId_When_CreateCategoryAsync()
	{
		// Arrange
		var createCategory = new CreateCategoryCommand { Title = "New Category" };
		var categoryId = Guid.CreateVersion7();


		_mediatorMock.Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(categoryId);

		// Act
		var result = await _categoryController.CreateCategoryAsync(createCategory);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		var actualCategoryId = Assert.IsType<CustomResult<Guid>>(okResult.Value);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
		Assert.Equal(categoryId, actualCategoryId.Value);
	}

	[Fact]
	public async Task ShouldBe_ReturnsOkResult_When_CategoryTitleChangeAsync()
	{
		// Arrange
		var categoryId = Guid.CreateVersion7();
		var categoryTitleChangeCommand = new CategoryTitleChangeCommand { Id = categoryId, Title = "New Title" };

		_mediatorMock.Setup(m => m.Send(It.IsAny<CategoryTitleChangeCommand>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(Result.Ok(categoryId));

		// Act
		var result = await _categoryController.CategoryTitleChangeAsync(categoryTitleChangeCommand);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
	}

	[Fact]
	public async Task ShouldBe_ReturnsOkResult_When_DeletePostAsync()
	{
		// Arrange
		var removeCategoryCommand = new RemoveCategoryCommand { Id = Guid.CreateVersion7() };

		_mediatorMock.Setup(m => m.Send(It.IsAny<RemoveCategoryCommand>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(Result.Ok());

		// Act
		var result = await _categoryController.DeleteCategoryAsync(removeCategoryCommand);

		// Assert
		var okResult = Assert.IsType<OkObjectResult>(result);
		Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
	}
}
