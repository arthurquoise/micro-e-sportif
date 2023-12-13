using System.Linq.Expressions;
using MicroESport.Joueurs.Domain.Models;

namespace MicroESport.Joueurs.Domain.Interfaces
{
    public interface IJoueurRepository
    {
        Task<Joueur> Save(Joueur joueur);
        Task<Joueur> Update(Joueur joueur);
        Task<bool> Delete(Joueur joueur);
        Task<Joueur?> FindById(string id);
        Task<IEnumerable<Joueur>> FindAll();
        Task<IEnumerable<Joueur>> FindBySpecification(Func<Joueur, bool> predicate);
    }
}
