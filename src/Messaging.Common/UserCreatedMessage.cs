using Messaging.Common;

namespace Messaging.Common
{
    public class UserCreatedMessage:IMessage
    {
        #region IMessage Members
        public int Version => 1;
        public string Type => MessagesConsts.TYPE_USER_CREATED;
        public string Sender { get; set; }

        #endregion

        public string Uuid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool Disabled { get; set; }

        public override string ToString()
        {
            return $"{Sender}=>{Uuid}-{UserName}-{Email}-{Disabled}";
        }

    }
}
