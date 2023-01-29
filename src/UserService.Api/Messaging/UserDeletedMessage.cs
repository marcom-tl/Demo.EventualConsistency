using Messaging.Common;
using UserService.Api.Mapping;

namespace UserService.Api.Messaging
{
    public class UserDeletedMessage:IMessage
    {
        public int Version => 1;
        public string Type => Consts.TYPE_USER_DELETED;

        public string Uuid { get; set; }
    }
}
