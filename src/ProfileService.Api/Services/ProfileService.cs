using AutoMapper;
using MassTransit;
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
        private readonly IPublishEndpoint _publisher;
        private readonly IMapper _mapper;

        public ProfileService(
            IProfileRepository repository,
            IPublishEndpoint publisher, 
            IMapper mapper)
        {
            _repository = repository;
            _publisher = publisher;
            _mapper = mapper;
        }
        public async Task<ProfileModel> CreateProfileAsync(ProfileModel obj)
        {
            var profile= await _repository.CreateProfileAsync(_mapper.Map<DomainProfile>(obj));

            await _publisher.Publish( Envelope.CreateEnvelope(_mapper.Map<ProfileCreatedMessage>(profile), Consts.SERVICE_NAME));

            return _mapper.Map<ProfileModel>(profile);
        }

        public async Task DeleteProfile(string uuid)
        {
            _repository.DeleteProfile(uuid);

        }

        public async Task<ProfileModel?> GetProfileAsync(string uuid)
        {
            var profile =await _repository.GetProfileAsync(uuid);
            return _mapper.Map<ProfileModel>(profile);
        }

        public async Task UpdateProfileAsync(ProfileModel obj)
        {
            var profile = await _repository.GetProfileAsync(obj.uuid);
            await _repository.UpdateProfileAsync(_mapper.Map<DomainProfile>(obj), profile);

            await _publisher.Publish(Envelope.CreateEnvelope(_mapper.Map<ProfileUpdatedMessage>(_mapper.Map<DomainProfile>(obj)), Consts.SERVICE_NAME));
        }
    }
}
