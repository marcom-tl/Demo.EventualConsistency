using MassTransit;
using Messaging.Common;
using ProfileService.Api.Domain;
using ProfileService.Api.Mapping;

namespace ProfileService.Api.Messaging
{
    public class UpdateUserConsumer : IConsumer<UserUpdatedMessage>
    {
        private readonly IProfileRepository _profileRepository;

        public UpdateUserConsumer(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task Consume(ConsumeContext<UserUpdatedMessage> context)
        {
            var message = context.Message;
            Console.Out.WriteLineAsync($"{Consts.SERVICE_NAME}- UserUpdatedMessage: {message}");

            var updatedProfile = await UpdateProfile(message);
            _profileRepository.UpdateProfileAsync(updatedProfile);
        }

        private async Task<Profile> UpdateProfile(UserUpdatedMessage userUpdatedMessage )
        {
            var profile = await _profileRepository.GetProfileByUserIdAsync(userUpdatedMessage.Id);

            profile.Email = userUpdatedMessage.Email;

            return profile;
        }
    }
}
