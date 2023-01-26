using Messaging.Common;
using ProfileService.Api.Mapping;

namespace ProfileService.Api.Messaging
{
    public class ProfileMessage:IMessage
    {
        #region IMessage Members
        public int Version => 1;
        public string Type => Consts.TYPE_PROFILE_CREATED;

        #endregion

        public int Id { get; set; }
        public string FistName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        
    }
}
