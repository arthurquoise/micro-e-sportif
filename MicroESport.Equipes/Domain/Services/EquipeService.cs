using MicroESport.Equipes.Domain.DTOs;
using MicroESport.Equipes.Domain.Interfaces;
using MicroESport.Equipes.Domain.Models;

namespace MicroESport.Equipes.Domain.Services
{
    public class EquipeService
    {
        private readonly IEquipeRepository _equipeService;
        private readonly HttpClient _httpClient;
        private const string joueurUrl = "https://localhost:7172/api/joueurs";

        public EquipeService(IEquipeRepository equipeRepository, IHttpClientFactory httpClientFactory)
        {
            _equipeService = equipeRepository;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<EquipeDTO>> FindAll()
        {
            // on ne recupere pas les joueurs ici pour optimiser
            return (await _equipeService.FindAll()).Select(e => (EquipeDTO)e);
        }

        public async Task<EquipeDTO?> FindById(string id)
        {
            var equipe = await _equipeService.FindById(id);
            EquipeDTO equipeDto = equipe!;

            equipeDto.Joueurs = (await _httpClient.GetFromJsonAsync<List<Joueur>>(joueurUrl + $"?equipeId={id}"))!;

            return equipeDto;
        }

        public async Task<IEnumerable<EquipeDTO>> FindBySpecification(Func<EquipeDTO, bool> predicate)
        {
            // on ne recupere pas les joueurs ici pour optimiser
            return (await _equipeService.FindAll()).Select(e => (EquipeDTO)e);
        }

        public async Task<EquipeDTO> Save(EquipeDTO equipeDto)
        {
            var equipe = await _equipeService.Save(equipeDto);

            equipeDto.Id = equipe.Id;

            var newJoueurs = new List<Joueur>();

            foreach (var joueur in equipeDto.Joueurs)
            {
                var existJoueur = await _httpClient.GetFromJsonAsync<Joueur>(joueurUrl + $"/{joueur.Id}");

                if (existJoueur == null)
                    throw new Exception("Joueur does not exist");

                //maj equipe joueur
                existJoueur.EquipeId = equipe.Id;

                await _httpClient.PutAsJsonAsync(joueurUrl + $"/{existJoueur.Id}", existJoueur);
                newJoueurs.Add(existJoueur);
            }
            equipeDto.Joueurs = newJoueurs;

            // call joueur save
            return equipeDto;
        }

        public async Task<EquipeDTO> Update(EquipeDTO equipeDto)
        {

            var equipe = await _equipeService.Update(equipeDto);

            List<Joueur> previousJoueurs = (await _httpClient.GetFromJsonAsync<List<Joueur>>(joueurUrl + $"?equipeId={equipe.Id}"))!;

            var newJoueurs = new List<Joueur>();

            foreach (var pj in previousJoueurs)
            {
                if(!equipeDto.Joueurs.Select(p=> p.Id).Contains(pj.Id))
                {
                    pj.EquipeId = null;
                    pj.Roaster = null;
                    await _httpClient.PutAsJsonAsync(joueurUrl + $"/{pj.Id}", pj);
                }
            }

            foreach (var joueur in equipeDto.Joueurs)
            {
                var existJoueur = await _httpClient.GetFromJsonAsync<Joueur>(joueurUrl + $"/{joueur.Id}");
                if (existJoueur == null)
                    throw new Exception("Joueur does not exist");

                //maj equipe joueur
                if (existJoueur.EquipeId != equipe.Id) // si il n'a pas bougé, on ne fait rien
                {
                    existJoueur.EquipeId = equipe.Id;
                    await _httpClient.PutAsJsonAsync(joueurUrl + $"/{existJoueur.Id}", existJoueur);
                }
                newJoueurs.Add(existJoueur);
            }

            equipeDto = equipe;
            equipeDto.Joueurs = newJoueurs;

            return equipe;
        }

        public async Task<bool> Delete(string id)
        {
            List<Joueur> previousPlayers = (await _httpClient.GetFromJsonAsync<List<Joueur>>(joueurUrl + $"?equipeId={id}"))!;

            foreach (var pj in previousPlayers)
            {
                pj.EquipeId = null;
                pj.Roaster = null;
                await _httpClient.PutAsJsonAsync(joueurUrl + $"/{pj.Id}", pj);
            }

            return await _equipeService.Delete(id);
        }
    }
}
