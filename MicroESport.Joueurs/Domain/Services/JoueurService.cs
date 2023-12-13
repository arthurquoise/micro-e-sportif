using MicroESport.Joueurs.Domain.Interfaces;

namespace MicroESport.Joueurs.Domain.Services
{
    public class JoueurService
    {
        private readonly IJoueurRepository _joueurRepository;

        public JoueurService(IJoueurRepository joueurRepository)
        {
            _joueurRepository = joueurRepository;
        }
    }
}
