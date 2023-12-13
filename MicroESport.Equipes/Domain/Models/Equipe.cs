using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MicroESport.Equipes.Domain.Models
{
    public class Equipe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Nom { get; set; }
    }
}
