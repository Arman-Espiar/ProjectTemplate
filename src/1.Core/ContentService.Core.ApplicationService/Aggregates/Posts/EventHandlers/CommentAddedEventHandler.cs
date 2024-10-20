﻿using EventBus.Messages.Aggregates.Posts.Events;

using Framework.Contract.ApplicationServices;

using MassTransit;

namespace ContentService.Core.ApplicationService.Aggregates.Posts.EventHandlers;
public class CommentAddedEventHandler : IDomainEventHandler<CommentAddedEvent>
{
	public Task Consume(ConsumeContext<CommentAddedEvent> context)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8; // Set the console output encoding to UTF-8
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine(context.Message);
		Console.ResetColor();

		return Task.CompletedTask;
	}
}