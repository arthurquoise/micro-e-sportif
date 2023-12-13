using System.Linq.Expressions;

namespace MicroESport.Joueur.Domain.Interfaces
{
    public interface IJoueurRepository
    {
        Task<Models.Joueur> Save(Models.Joueur joueur);
        Task<Models.Joueur> Update(Models.Joueur joueur);
        Task<bool> Delete(Models.Joueur joueur);
        Task<Models.Joueur?> FindById(string id);
        Task<IEnumerable<Models.Joueur>> FindAll();
        Task<IEnumerable<Models.Joueur>> FindBySpecification(Expression<Func<Models.Joueur, bool>> callback);
    }
}
