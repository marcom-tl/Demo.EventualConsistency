using Messaging.Common;
using UserService.Api.Mapping;

namespace UserService.Api.Messaging
{
    public class UserCreatedMessage:IMessage
    {
        #region IMessage Members
        public int Version => 1;
        public string Type => Consts.TYPE_USER_CREATED;

        #endregion

        public string Uuid { get; set; }
        public string FistName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Date Of Birth
        /// </summary>
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        
    }
}
