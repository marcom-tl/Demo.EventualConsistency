using ProfileService.Api.Messaging;
using ProfileService.Api.Models;
using AutoMapper;

namespace ProfileService.Api.Mapping
{
    
    using DomainProfile=Domain.Profile;
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<DomainProfile, ProfileModel>().ReverseMap();

            CreateMap<DomainProfile, ProfileCreatedMessage>().ReverseMap();

            CreateMap<DomainProfile, ProfileUpdatedMessage>().ReverseMap();
        }
    }
}
