using Messaging.Common;
using ProfileService.Api.Mapping;

namespace ProfileService.Api.Messaging
{
    public class ProfileDeletedMessage:IMessage
    {
        public int Version => 1;
        public string Type => Consts.TYPE_PROFILE_DELETED;

        public string Uuid { get; set; }
    }
}
