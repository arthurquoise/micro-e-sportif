using System.Linq.Expressions;
using MicroESport.Joueurs.Domain.Interfaces;

namespace MicroESport.Joueurs.Infrastructure.Repositories
{
    public class JoueurMongoRepository : IJoueurRepository
    {
        public Task<bool> Delete(Domain.Models.Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Models.Joueur>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Joueur?> FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Models.Joueur>> FindBySpecification(Expression<Func<Domain.Models.Joueur, bool>> callback)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Joueur> Save(Domain.Models.Joueur joueur)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Joueur> Update(Domain.Models.Joueur joueur)
        {
            throw new NotImplementedException();
        }
    }
}
