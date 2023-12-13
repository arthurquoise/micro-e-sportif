using MicroESport.Joueurs.Domain.Interfaces;
using MicroESport.Joueurs.Domain.Models;
using System.Linq.Expressions;

namespace MicroESport.Joueurs.Domain.Services
{
    public class JoueurService
    {
        private readonly IJoueurRepository _joueurRepository;

        public JoueurService(IJoueurRepository joueurRepository)
        {
            _joueurRepository = joueurRepository;
        }

        public async Task<IEnumerable<Joueur>> FindAll()
        {
            return await _joueurRepository.FindAll();
        }

        public async Task<Joueur?> FindById(string id)
        {
            return await _joueurRepository.FindById(id);
        }

        public async Task<IEnumerable<Joueur>> FindBySpecification(Expression<Func<Joueur, bool>> predicate)
        {
            return await _joueurRepository.FindBySpecification(predicate);
        }

        public async Task<Joueur> Save(Joueur joueur)
        {
            return await _joueurRepository.Save(joueur);
        }

        public async Task<Joueur> Update(Joueur joueur)
        {
            return await _joueurRepository.Update(joueur);
        }

        public async Task<bool> Delete(string id)
        {
            return await _joueurRepository.Delete(id);
        }
    }
}
