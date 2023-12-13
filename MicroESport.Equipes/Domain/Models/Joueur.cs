using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroESport.Equipes.Domain.Models
{
    public class Joueur
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Pseudo { get; set; }
        public string? Poste { get; set; }
        public string? Roaster { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? Pays { get; set; }
        public string? EquipeId { get; set; }
    }
}
