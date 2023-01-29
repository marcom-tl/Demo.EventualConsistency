using AutoMapper;
using MassTransit;
using Messaging.Common;
using UserService.Api.Domain;
using UserService.Api.Mapping;
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
            var user = await _repository.CreateUserAsync(_mapper.Map<User>(obj));

            var message = _mapper.Map<UserCreatedMessage>(user);
            message.Sender = Consts.SERVICE_NAME;
            await _publisher.Publish(message);

            return _mapper.Map<UserModel>(user);
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
            var message = _mapper.Map<UserUpdatedMessage>(_mapper.Map<User>(obj));
            message.Sender = Consts.SERVICE_NAME;
            await _publisher.Publish(message);
        }
    }
}
