using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Locations.Data.Entities
{
    public class PropertyLocation
    {

        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PropertyId { get; set; }
        public int LocationId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
