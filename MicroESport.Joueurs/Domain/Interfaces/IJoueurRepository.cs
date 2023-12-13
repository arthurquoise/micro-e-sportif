using System.Linq.Expressions;
using MicroESport.Joueurs.Domain.Models;

namespace MicroESport.Joueurs.Domain.Interfaces
{
    public interface IJoueurRepository
    {
        Task<Joueur> Save(Joueur joueur);
        Task<Joueur> Update(Joueur joueur);
        Task<bool> Delete(string id);
        Task<Joueur?> FindById(string id);
        Task<IEnumerable<Joueur>> FindAll();
        Task<IEnumerable<Joueur>> FindBySpecification(Expression<Func<Joueur, bool>> predicate);
    }
}
