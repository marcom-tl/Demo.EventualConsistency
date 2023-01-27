using MassTransit;
using Messaging.Common;

namespace UserService.Api.Messaging
{
    public class CreateProfileConsumer:IConsumer<Envelope>
    {
        public  Task Consume(ConsumeContext<Envelope> context)
        {
            Console.Out.WriteLineAsync($"MessageArrived: {context.Message.JsonContent}");
            return Task.CompletedTask;
        }
    }
}
