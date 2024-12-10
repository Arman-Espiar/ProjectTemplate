using ContentService.Core.Contracts.Aggregates.Categories.Commands;
using ContentService.Core.Contracts.Aggregates.Posts.Commands;
using ContentService.Core.Contracts.Aggregates.Posts.Commands.Comment;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetAll;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostAndCommentById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.GetPostById;
using ContentService.Core.Contracts.Aggregates.Posts.Queries.ResultViewModel;

using Gridify;

using MDF.Framework.Endpoints.Api;
using MDF.Framework.Extensions.Results;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ContentService.Endpoints.API.Controllers;
[Route("api/[controller]/[action]")]
public class PostController : BaseController
{
	public PostController(IMediator mediator) : base(mediator)
	{
	}

	[ProducesResponseType(type: typeof(CustomResult<List<PostQueryResult>>), statusCode: StatusCodes.Status200OK)]
	[HttpGet("")]
	public Task<IActionResult> GetAllPostAsync(GetAllPostQuery getAllPostQuery)
	{
		return QueryAsync<GetAllPostQuery, List<PostQueryResult>>(getAllPostQuery);
	}
	[ProducesResponseType(type: typeof(CustomResult<List<PostWithCommentsQueryResult>>), statusCode: StatusCodes.Status200OK)]
	[HttpGet("")]
	public Task<IActionResult> GetAllPostWithCommentAsync(GetAllPostWithCommentQuery postWithCommentQuery)
	{
		return QueryAsync<GetAllPostWithCommentQuery, List<PostWithCommentsQueryResult>>(postWithCommentQuery);
	}

	[ProducesResponseType(type: typeof(CustomResult<PostQueryResult>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpGet("")]
	public Task<IActionResult> GetPostAsync(GetPostByIdQuery id)
	{
		return QueryAsync<GetPostByIdQuery, PostQueryResult>(id);
	}

	[ProducesResponseType(type: typeof(CustomResult<PostQueryResult>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpGet("")]
	public Task<IActionResult> GetPostAndCommentsAsync(GetPostWithCommentsByIdQuery id)
	{
		return QueryAsync<GetPostWithCommentsByIdQuery, PostWithCommentsQueryResult>(id);
	}

	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpPost("")]
	public Task<IActionResult> CreatePostAsync([FromBody] CreatePostCommand createPostCommand)
	{
		return CreateAsync<CreatePostCommand, Guid>(createPostCommand);
	}
	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpPut("")]
	public Task<IActionResult> AddCategoryAsync([FromBody] AddCategoryCommand addCategoryCommand)
	{
		return EditAsync<AddCategoryCommand, Guid>(addCategoryCommand);
	}

	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpPatch("")]
	public Task<IActionResult> ChangeCategoryAsync([FromBody] ChangeCategoryCommand changeCategoryCommand)
	{
		return EditAsync<ChangeCategoryCommand, Guid>(changeCategoryCommand);
	}

	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpDelete("")]
	public Task<IActionResult> RemovePostCategoryAsync([FromBody] RemovePostCategoryCommand removePostCategory)
	{
		return DeleteAsync<RemovePostCategoryCommand>(removePostCategory);
	}

	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpPut("")]
	public Task<IActionResult> UpdatePostAsync([FromBody] UpdatePostCommand updatePostCommand)
	{
		//todo mapper her
		return EditAsync<UpdatePostCommand, Guid>(updatePostCommand);
	}

	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpDelete("")]
	public Task<IActionResult> DeletePostAsync([FromBody] RemovePostCommand removePostCommand)
	{
		return DeleteAsync<RemovePostCommand>(removePostCommand);
	}
	#region Comment
	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpPost("")]
	public Task<IActionResult> AddCommentToPostAsync([FromBody] AddCommentToPostCommand addCommentToPostCommand)
	{
		return CreateAsync<AddCommentToPostCommand, Guid>(addCommentToPostCommand);
	}

	[ProducesResponseType(type: typeof(CustomResult<Guid>), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpPut("")]
	public Task<IActionResult> EditCommentAsync([FromBody] EditCommentThePostCommand editCommentThePostCommand)
	{
		return EditAsync<EditCommentThePostCommand, Guid>(editCommentThePostCommand);
	}

	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status200OK)]
	[ProducesResponseType(type: typeof(CustomResult), statusCode: StatusCodes.Status400BadRequest)]
	[HttpDelete("")]
	public Task<IActionResult> DeleteCommentAsync([FromBody] RemoveCommentFromPostCommand removeCommentFromPostCommand)
	{
		return DeleteAsync<RemoveCommentFromPostCommand>(removeCommentFromPostCommand);
	}
	#endregion
}
