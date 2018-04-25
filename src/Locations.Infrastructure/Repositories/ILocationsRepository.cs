using Locations.Infrastructure.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locations.Infrastructure.Repositories
{
    using Locations.Data.Entities;

    public interface ILocationsRepository
    {
        Task<Locations> GetAsync(int locationId);

        Task<List<Locations>> GetLocationListAsync();

        Task<UserLocation> GetUserLocationAsync(string userId);

        Task<List<Locations>> GetCurrentUserRegionsListAsync(LocationRequest currentPosition);

        Task AddUserLocationAsync(UserLocation location);

        Task UpdateUserLocationAsync(UserLocation userLocation);
    }
}
