using MicroESport.Equipes.Domain.Models;
using MicroESport.Equipes.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroESport.Equipes.Infrastructure.Controllers
{
    [Route("api/equipes")]
    [ApiController]
    public class EquipesController : ControllerBase
    {
        private readonly EquipeService _equipeService;

        public EquipesController(EquipeService equipeService)
        {
            _equipeService = equipeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Equipe>> FindAll()
        {
            return await _equipeService.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<Equipe?> FindById(string id)
        {
            return await _equipeService.FindById(id);
        }

        [HttpPost]
        public async Task<Equipe> Save(Equipe equipe)
        {
            return await _equipeService.Save(equipe);
        }

        [HttpPut]
        public async Task<Equipe> Update(Equipe equipe)
        {
            return await _equipeService.Update(equipe);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _equipeService.Delete(id);
        }
    }
}
