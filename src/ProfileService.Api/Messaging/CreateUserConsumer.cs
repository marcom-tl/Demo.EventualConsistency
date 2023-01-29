using MassTransit;
using Messaging.Common;
using ProfileService.Api.Mapping;

namespace ProfileService.Api.Messaging
{
    public class CreateUserConsumer : IConsumer<UserCreatedMessage>
    {
        public Task Consume(ConsumeContext<UserCreatedMessage> context)
        {
            Console.Out.WriteLineAsync($"{Consts.SERVICE_NAME}- UserCreatedMessage: {context.Message.ToString()}");
            return Task.CompletedTask;
        }
    }
}
