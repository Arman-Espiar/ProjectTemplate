using ContentService.Core.Domain.Aggregates.Categories;
using ContentService.Core.Domain.Aggregates.Posts;

using Framework.Infrastructure.Commands;
using Framework.Infrastructure.Commands.ShadowProperties;
using Framework.Infrastructure.Conversions.Extensions;

using MassTransit;

using Microsoft.EntityFrameworkCore;

namespace ContentService.Infrastructure.Persistence.Sql.Commands.Common;
public class ContentCommandDbContext : BaseCommandDbContext
{
	public DbSet<Post> Posts { get; set; }
	public DbSet<Category> Categories { get; set; }
	public ContentCommandDbContext(DbContextOptions<ContentCommandDbContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
	}
	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		base.ConfigureConventions(configurationBuilder);
		configurationBuilder.UseDateTimeAsUtcConversion();
		configurationBuilder.UseNullableDateTimeAsUtcConversion();
	}
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.AddCommonShadowProperties();
		builder.ApplyConfigurationsFromAssembly
		(typeof(ContentCommandDbContext).Assembly);

		//اضافه کردن OutBox pattern Masstransit
		builder.AddInboxStateEntity();
		builder.AddOutboxMessageEntity();
		builder.AddOutboxStateEntity();
	}
}