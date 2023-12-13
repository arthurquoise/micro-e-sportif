using System.Linq.Expressions;
using MicroESport.Equipes.Domain.Models;

namespace MicroESport.Equipes.Domain.Interfaces
{
    public interface IEquipeRepository
    {
        Task<Equipe> Save(Equipe equipe);
        Task<Equipe> Update(Equipe equipe);
        Task<bool> Delete(string id);
        Task<Equipe?> FindById(string id);
        Task<IEnumerable<Equipe>> FindAll();
        Task<IEnumerable<Equipe>> FindBySpecification(Func<Equipe, bool> predicate);
    }
}
