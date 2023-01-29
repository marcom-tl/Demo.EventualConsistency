using Messaging.Common;


namespace Messaging.Common
{
    public class ProfileDeletedMessage:IMessage
    {
        public int Version => 1;
        public string Type => MessagesConsts.TYPE_PROFILE_DELETED;
        public string Sender { get; set; }

        public string Uuid { get; set; }
        public override string ToString()
        {
            return $"{Sender}=>{Uuid}";
        }
    }
}
