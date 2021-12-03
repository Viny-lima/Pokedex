﻿using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    public interface IRepositoryEntity
    {
        List<TypeDB> GetTypes();
        List<MoveDB> GetMoves();
        List<PokemonDB> GetPokemons();
        List<AbilityDB> GetAbilities();    }
}
