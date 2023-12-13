using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MicroESport.Equipes.Domain.Models;

namespace MicroESport.Equipes.Domain.DTOs
{
    public class EquipeDTO
    {
        public string? Id { get; set; }
        public string? Nom { get; set; }
        public List<Joueur> Joueurs { get; set; } = new();

        public static implicit operator EquipeDTO(Equipe e) => new() { Id = e.Id, Nom = e.Nom };
        public static implicit operator Equipe(EquipeDTO ed) => new() { Id = ed.Id, Nom = ed.Nom };
    }
}
