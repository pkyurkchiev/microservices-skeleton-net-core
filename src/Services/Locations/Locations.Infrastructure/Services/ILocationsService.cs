using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locations.Infrastructure.Services
{
    using Locations.Data.Entities;

    public interface ILocationsService
    {
        Task<Locations> GetLocation(int locationId);

        Task<UserLocation> GetUserLocation(string id);

        Task<List<Locations>> GetAllLocation();

        //Task<bool> AddOrUpdateUserLocation(string userId, LocationRequest locRequest);
    }
}
