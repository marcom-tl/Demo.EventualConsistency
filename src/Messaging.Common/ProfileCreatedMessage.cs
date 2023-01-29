using Messaging.Common;


namespace Messaging.Common
{
    public class ProfileCreatedMessage:IMessage
    {
        #region IMessage Members
        public int Version => 1;
        public string Type => MessagesConsts.TYPE_PROFILE_CREATED;
        public string Sender { get; set; }

        #endregion

        public string Uuid { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Sender}=>{Uuid}-{FirstName}-{LastName}-{Email}-{Dob}";
        }
    }
}
