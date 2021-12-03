using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class PokemonAPI : ObservableObject
    {
        [JsonProperty("id")]
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                SetProperty(ref _id, value, nameof(Id));
            }
        }

        [JsonProperty("name")]
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value, nameof(Name));
            }
        }

        [JsonProperty("height")]
        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                SetProperty(ref _height, value, nameof(Height));
            }
        }

        [JsonProperty("weight")]
        private int _weigth;
        public int Weight
        {
            get
            {
                return _weigth;
            }
            set
            {
                SetProperty(ref _weigth, value, nameof(Weight));
            }
        }

        [JsonProperty("base_experience")]
        private int _baseExperience;
        public int BaseExperience
        {
            get
            {
                return _baseExperience;
            }
            set
            {
                SetProperty(ref _baseExperience, value, nameof(BaseExperience));
            }
        }       

        [JsonProperty("stats")]
        private List<StatsAPI> _statusBase;
        public List<StatsAPI> StatusBase
        {
            get
            {
                return _statusBase;
            }
            set
            {
                SetProperty(ref _statusBase, value, nameof(StatusBase));
            }
        }

        [JsonProperty("sprites")]
        private SpritesAPI _sprites;
        public SpritesAPI Sprites
        {
            get
            {
                return _sprites;
            }
            set
            {
                SetProperty(ref _sprites, value, nameof(Sprites));
            }
        }

        [JsonProperty("abilities")]
        private List<AbilityAPI> _abilities;
        public List<AbilityAPI> Abilities
        {
            get
            {
                return _abilities;
            }
            set
            {
                SetProperty(ref _abilities, value, nameof(Abilities));
            }
        }

        [JsonProperty("types")]
        private List<TypeAPI> _types;
        public List<TypeAPI> Types
        {
            get
            {
                return _types;
            }
            set
            {
                SetProperty(ref _types, value, nameof(Types));
            }
        }

        [JsonProperty("moves")]
        private List<MoveAPI> _moves;
        public List<MoveAPI> Moves
        {
            get
            {
                return _moves;
            }
            set
            {
                SetProperty(ref _moves, value, nameof(Moves));
            }
        }                      
    }
}