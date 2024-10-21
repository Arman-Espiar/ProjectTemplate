using MDF.Infrastructure.Commands;

namespace ContentService.Infrastructure.Persistence.Sql.Commands.Common;
public class CommonUnitOfWork : BaseEntityFrameworkUnitOfWork<ContentCommandDbContext>
{
	public CommonUnitOfWork(ContentCommandDbContext dbContext) : base(dbContext)
	{
	}
}
