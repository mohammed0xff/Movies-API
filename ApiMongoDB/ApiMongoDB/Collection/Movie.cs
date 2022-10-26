using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongoDB.Collection
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("rate")]
        public int? Rate { get; set; }

        [BsonElement("release_date")]
        public DateTime ReleaseDate { get; set; }
    }
}
