﻿using MicroESport.Joueurs.Domain.Interfaces;
using MicroESport.Joueurs.Domain.Models;

namespace MicroESport.Joueurs.Domain.Services
{
    public class JoueurService
    {
        private readonly IJoueurRepository _joueurService;

        public JoueurService(IJoueurRepository joueurRepository)
        {
            _joueurService = joueurRepository;
        }

        public async Task<IEnumerable<Joueur>> FindAll()
        {
            return await _joueurService.FindAll();
        }

        public async Task<Joueur?> FindById(string id)
        {
            return await _joueurService.FindById(id);
        }

        public async Task<IEnumerable<Joueur>> FindBySpecification(Func<Joueur, bool> predicate)
        {
            return await _joueurService.FindBySpecification(predicate);
        }

        public async Task<Joueur> Save(Joueur joueur)
        {
            return await _joueurService.Save(joueur);
        }

        public async Task<Joueur> Update(Joueur joueur)
        {
            return await _joueurService.Update(joueur);
        }

        public async Task<bool> Delete(string id)
        {
            return await _joueurService.Delete(id);
        }
    }
}
