using System.Collections.Concurrent;
using UserService.Api.Domain;

namespace UserService.Api.Infrastructure
{
    public class InMemoryUserRepository:IUserRepository
    {

        private ConcurrentDictionary<string, User> _users = new();

        public async Task<User> CreateUserAsync(User obj)
        {
            var _currentId = Guid.NewGuid();

            obj.Id = _currentId.ToString();

            return _users.AddOrUpdate(obj.Id, obj, (key, current) => obj);
        }

        public async Task DeleteUser(string uuid)
        {
            _users.Remove(uuid, out User removedObj);
        }

        public async Task<User> GetUserAsync(string uuid)
        {
            if (_users.TryGetValue(uuid, out User obj)) ;
                return obj;
        }

        public async Task UpdateUserAsync(User obj)
        {
            _users.AddOrUpdate(obj.Id, obj, (key, current) => obj);
        }
    }
}
