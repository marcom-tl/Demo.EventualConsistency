using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using ProfileService.Api.Domain;

namespace ProfileService.Api.Infrastructure
{
    public class InMemoryProfileRepository:IProfileRepository
    {
        private readonly object _currentIdLock = new();
        private int _currentId = 1;
        private ConcurrentDictionary<int,Profile> _profiles=new();

        public async Task<Profile> CreateProfileAsync(Profile obj)
        {
            lock (_currentIdLock)
            {
                obj.Id = _currentId;
                _currentId++;
            }
            return _profiles.AddOrUpdate(obj.Id, obj, (key,current ) => current);
        }

        public async Task DeleteProfile(int objId)
        {
            _profiles.Remove(objId, out Profile removedObj);
        }

        public async Task<Profile> GetProfileAsync(int objId)
        {
            if (_profiles.TryGetValue(objId, out Profile obj));
                return obj;
        }

        public async Task UpdateProfileAsync(Profile obj)
        {
            _profiles.TryUpdate(obj.Id, obj, obj);
        }
    }
}
