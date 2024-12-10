using ContentService.Core.Domain.Aggregates.Posts;
using ContentService.Core.Domain.Aggregates.Posts.Entities;

using MDF.Framework.LayersContracts.Persistence.Commands;

using Microsoft.EntityFrameworkCore;

namespace ContentService.Core.Contracts.Aggregates.Posts.CommandRepositories;

public interface IPostCommandRepository : ICommandRepository<Post>
{
	//اینجا باید متد های مورد نیاز را نوشت

}