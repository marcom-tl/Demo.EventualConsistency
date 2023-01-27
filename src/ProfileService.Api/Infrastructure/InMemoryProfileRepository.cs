using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using ProfileService.Api.Domain;

namespace ProfileService.Api.Infrastructure
{
    public class InMemoryProfileRepository:IProfileRepository
    {
        private readonly object _currentIdLock = new();
        private Guid _currentId = Guid.NewGuid();
        private ConcurrentDictionary<string, Profile> _profiles=new();

        public async Task<Profile> CreateProfileAsync(Profile obj)
        {
            lock (_currentIdLock)
            {
                obj.Uuid = _currentId.ToString();
            }
            return _profiles.AddOrUpdate(obj.Uuid, obj, (key,current ) => obj);
        }

        public async Task DeleteProfile(string uuid)
        {
            _profiles.Remove(uuid, out Profile removedObj);
        }

        public async Task<Profile> GetProfileAsync(string uuid)
        {
            if (_profiles.TryGetValue(uuid, out Profile obj));
                return obj;
        }

        public async Task UpdateProfileAsync(Profile obj, Profile oldObj)
        {
            _profiles.AddOrUpdate(obj.Uuid, obj, (key, current) => obj);
        }
    }
}
