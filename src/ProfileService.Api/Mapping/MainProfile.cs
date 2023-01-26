using ProfileService.Api.Messaging;
using ProfileService.Api.Models;

namespace ProfileService.Api.Mapping
{
    using  AutoMapper;
    using DomainPofile=Domain.Profile;
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<DomainPofile, ProfileModel>().ReverseMap();

            CreateMap<DomainPofile, ProfileCreatedMessage>().ReverseMap();
        }
    }
}
