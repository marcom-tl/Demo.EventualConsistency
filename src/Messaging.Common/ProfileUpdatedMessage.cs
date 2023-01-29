using Messaging.Common;

namespace Messaging.Common
{
    public class ProfileUpdatedMessage:IMessage
    {
        public int Version => 1;
        public string Type => MessagesConsts.TYPE_PROFILE_UPDATED;
        public string Sender { get; set; }


        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        // IMPROVEMENT: send the old and the new version of the profile
        // public Profile OldProfile { get; set; }
        // public Profile NewProfile { get; set; }
        public override string ToString()
        {
            return $"{Sender}=>{Id}-{FirstName}-{LastName}-{Email}-{Dob}";
        }
    }
}
