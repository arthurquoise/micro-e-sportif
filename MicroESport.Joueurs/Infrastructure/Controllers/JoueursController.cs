﻿using MicroESport.Joueurs.Domain.Models;
using MicroESport.Joueurs.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroESport.Joueurs.Infrastructure.Controllers
{
    [Route("api/joueurs")]
    [ApiController]
    public class JoueursController : ControllerBase
    {
        private readonly JoueurService _joueurService;

        public JoueursController(JoueurService joueurService)
        {
            _joueurService = joueurService;
        }

        [HttpGet]
        public async Task<IEnumerable<Joueur>> FindAll()
        {
            return await _joueurService.FindAll();
        }

        [HttpGet("{id}")]
        public async Task<Joueur?> FindById(string id)
        {
            return await _joueurService.FindById(id);
        }

        [HttpPost]
        public async Task<Joueur> Save(Joueur joueur)
        {
            return await _joueurService.Save(joueur);
        }

        [HttpPut]
        public async Task<Joueur> Update(Joueur joueur)
        {
            return await _joueurService.Update(joueur);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await _joueurService.Delete(id);
        }
    }
}
