using AutoMapper;
using Messaging.Common;
using UserService.Api.Domain;

using UserService.Api.Models;

namespace UserService.Api.Mapping
{
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();

            CreateMap<User, UserCreatedMessage>().ReverseMap();

            CreateMap<User, UserUpdatedMessage>().ReverseMap();
        }
    }
}
