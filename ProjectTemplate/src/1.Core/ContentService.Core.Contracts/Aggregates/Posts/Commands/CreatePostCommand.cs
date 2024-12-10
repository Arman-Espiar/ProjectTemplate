using MDF.Framework.LayersContracts.ApplicationServices.MediatorExtensions.CQRS;

namespace ContentService.Core.Contracts.Aggregates.Posts.Commands;
public class CreatePostCommand : BaseCommand<Guid>
{
	public string Title { get; set; }
	public string Description { get; set; }
	public string Text { get; set; }
}
