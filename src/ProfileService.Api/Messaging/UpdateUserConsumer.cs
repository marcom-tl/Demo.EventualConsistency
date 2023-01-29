using MassTransit;
using Messaging.Common;
using ProfileService.Api.Mapping;

namespace ProfileService.Api.Messaging
{
    public class UpdateUserConsumer : IConsumer<UserUpdatedMessage>
    {
        public Task Consume(ConsumeContext<UserUpdatedMessage> context)
        {
            Console.Out.WriteLineAsync($"{Consts.SERVICE_NAME}- UserUpdatedMessage: {context.Message}");
            return Task.CompletedTask;
        }
    }
}
