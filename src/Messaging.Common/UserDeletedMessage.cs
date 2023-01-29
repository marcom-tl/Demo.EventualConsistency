using Messaging.Common;

namespace Messaging.Common
{
    public class UserDeletedMessage:IMessage
    {
        public int Version => 1;
        public string Type => MessagesConsts.TYPE_USER_DELETED;
        public string Sender { get; set; }

        public string Id { get; set; }
    }
}
