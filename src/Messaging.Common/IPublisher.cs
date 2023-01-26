namespace Messaging.Common
{
    public interface IPublisher
    {
        Task PublishAsync(Envelope message);
    }
}
