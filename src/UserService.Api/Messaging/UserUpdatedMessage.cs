using Messaging.Common;
using UserService.Api.Mapping;

namespace UserService.Api.Messaging
{
    public class UserUpdatedMessage:IMessage
    {
        public int Version => 1;
        public string Type => Consts.TYPE_USER_UPDATED;


        public string Uuid { get; set; }
        public string FistName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        // IMPROVEMENT: send the old and the new version of the profile
        // public Profile OldProfile { get; set; }
        // public Profile NewProfile { get; set; }
    }
}
