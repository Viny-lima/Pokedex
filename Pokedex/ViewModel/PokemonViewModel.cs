using Microsoft.Toolkit.Mvvm.ComponentModel;
using Pokedex.Model.Entities;
using Pokedex.Model.PokeApi;
using System.Collections.Generic;

namespace Pokedex.ViewModel
{
    public class PokemonViewModel : ObservableObject
    {
        private PokemonDB _pokemon = new PokemonDB();
        public PokemonDB This
        {
            get
            {
                
                return _pokemon;
            }
            set
            {
                SetProperty(ref _pokemon, value);
            }
        }
        
        public string Sprite
        {
            get
            {
                if (string.IsNullOrEmpty(_pokemon.SpritesOfficialArtwork))
                {
                    return "../Assets/Components/DEFAULT_POKEMON.png";
                }

                return _pokemon.SpritesOfficialArtwork;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _pokemon.SpritesOfficialArtwork = value;
                }

            }
        }

    }
}