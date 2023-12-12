using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroESport.Equipe.Domain.Models
{
    public class Equipe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
