using Messaging.Common;

namespace ProfileService.Api.Messaging
{
    public class StubPublisher:IPublisher
    {
        public async Task PublishAsync(Envelope message)
        {
            //does nothing
        }
    }
}
