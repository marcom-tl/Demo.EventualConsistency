using Messaging.Common;

namespace Messaging.Common
{
    public class UserUpdatedMessage:IMessage
    {
        public int Version => 1;
        public string Type => MessagesConsts.TYPE_USER_UPDATED;
        public string Sender { get; set; }


        public string Uuid { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool Disabled { get; set; }

        // IMPROVEMENT: send the old and the new version of the profile
        // public User OldUser { get; set; }
        // public User NewUser { get; set; }

        public override string ToString()
        {
            return $"{Sender}=>{Uuid}-{UserName}-{Email}-{Disabled}";
        }
    }
}
