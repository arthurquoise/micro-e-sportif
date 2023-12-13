using MicroESport.Equipes.Domain.Interfaces;
using MicroESport.Equipes.Domain.Models;

namespace MicroESport.Equipes.Domain.Services
{
    public class EquipeService
    {
        private readonly IEquipeRepository _equipeService;

        public EquipeService(IEquipeRepository equipeRepository)
        {
            _equipeService = equipeRepository;
        }

        public async Task<IEnumerable<Equipe>> FindAll()
        {
            return await _equipeService.FindAll();
        }

        public async Task<Equipe?> FindById(string id)
        {
            return await _equipeService.FindById(id);
        }

        public async Task<IEnumerable<Equipe>> FindBySpecification(Func<Equipe, bool> predicate)
        {
            return await _equipeService.FindBySpecification(predicate);
        }

        public async Task<Equipe> Save(Equipe equipe)
        {
            return await _equipeService.Save(equipe);
        }

        public async Task<Equipe> Update(Equipe equipe)
        {
            return await _equipeService.Update(equipe);
        }

        public async Task<bool> Delete(string id)
        {
            return await _equipeService.Delete(id);
        }
    }
}
