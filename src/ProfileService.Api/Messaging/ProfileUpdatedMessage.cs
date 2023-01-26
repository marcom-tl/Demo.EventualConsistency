using Messaging.Common;
using ProfileService.Api.Mapping;

namespace ProfileService.Api.Messaging
{
    public class ProfileUpdatedMessage:IMessage
    {
        public int Version => 1;
        public string Type => Consts.TYPE_PROFILE_UPDATED;


        public int Id { get; set; }
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
