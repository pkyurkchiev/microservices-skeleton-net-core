using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Locations.Data
{
    using Locations.Data.Entities;

    public class LocationsContext
    {
        private readonly IMongoDatabase _database = null;

        public LocationsContext(IOptions<LocationSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<UserLocation> UserLocation
        {
            get
            {
                return _database.GetCollection<UserLocation>("UserLocation");
            }
        }

        public IMongoCollection<Locations> Locations
        {
            get
            {
                return _database.GetCollection<Locations>("Locations");
            }
        }
    }
}
