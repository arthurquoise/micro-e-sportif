﻿using MicroESport.Joueur.Domain.Interfaces;

namespace MicroESport.Joueur.Domain.Services
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