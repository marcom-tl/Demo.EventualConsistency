using MassTransit;
using Messaging.Common;
using UserService.Api.Mapping;

namespace UserService.Api.Messaging
{
    public class UpdateProfileConsumer:IConsumer<ProfileUpdatedMessage>
    {
        public Task Consume(ConsumeContext<ProfileUpdatedMessage> context)
        {
            Console.Out.WriteLineAsync($"{Consts.SERVICE_NAME}- UpdateProfileConsumer: {context.Message.ToString()}");
            return Task.CompletedTask;
        }
    }
}
