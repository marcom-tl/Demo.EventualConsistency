using MassTransit;
using Messaging.Common;
using UserService.Api.Mapping;

namespace UserService.Api.Messaging
{
    public class CreateProfileConsumer:IConsumer<ProfileCreatedMessage>
    {
        public Task Consume(ConsumeContext<ProfileCreatedMessage> context)
        {
            Console.Out.WriteLineAsync($"{Consts.SERVICE_NAME}- ProfileCreatedMessage: {context.Message.ToString()}");
            return Task.CompletedTask;
        }
    }
}
