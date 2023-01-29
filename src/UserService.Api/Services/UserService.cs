using AutoMapper;
using MassTransit;
using Messaging.Common;
using UserService.Api.Domain;
using UserService.Api.Mapping;
using UserService.Api.Messaging;
using UserService.Api.Models;

namespace UserService.Api.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IPublishEndpoint _publisher;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository repository,
            IPublishEndpoint publisher,
            IMapper mapper)
        {
            _repository = repository;
            _publisher = publisher;
            _mapper = mapper;
        }

        public async Task<UserModel> CreateUserAsync(UserModel obj)
        {
            var profile = await _repository.CreateUserAsync(_mapper.Map<User>(obj));

            await _publisher.Publish(Envelope.CreateEnvelope(_mapper.Map<UserCreatedMessage>(profile), Consts.SERVICE_NAME));

            return _mapper.Map<UserModel>(profile);
        }

        public async Task DeleteUser(string uuid)
        {
            _repository.DeleteUser(uuid);
        }

        public async Task<UserModel?> GetUserAsync(string uuid)
        {
            var profile = await _repository.GetUserAsync(uuid);
            return _mapper.Map<UserModel>(profile);
        }

        public async Task UpdateUserAsync(UserModel obj)
        {
            await _repository.UpdateUserAsync(_mapper.Map<User>(obj));

            await _publisher.Publish(Envelope.CreateEnvelope(_mapper.Map<UserUpdatedMessage>(_mapper.Map<User>(obj)), Consts.SERVICE_NAME));
        }
    }
}
