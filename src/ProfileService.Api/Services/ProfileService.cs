using AutoMapper;
using Messaging.Common;
using ProfileService.Api.Domain;
using ProfileService.Api.Mapping;
using ProfileService.Api.Messaging;
using ProfileService.Api.Models;
using DomainProfile= ProfileService.Api.Domain.Profile;
namespace ProfileService.Api.Services
{
    public class ProfileService: IProfileService
    {
        private readonly IProfileRepository _repository;
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;

        public ProfileService(
            IProfileRepository repository, 
            IPublisher publisher, 
            IMapper mapper)
        {
            _repository = repository;
            _publisher = publisher;
            _mapper = mapper;
        }
        public async Task<ProfileModel> CreateProfileAsync(ProfileModel obj)
        {
            var profile= await _repository.CreateProfileAsync(_mapper.Map<DomainProfile>(obj));

            await _publisher.PublishAsync(new Envelope(_mapper.Map<ProfileMessage>(profile), Consts.SERVICE_NAME));

            return _mapper.Map<ProfileModel>(profile);
        }

        public async Task DeleteProfile(int objId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileModel> GetProfileAsync(int objId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProfileAsync(ProfileModel obj)
        {
            
        }
    }
}
