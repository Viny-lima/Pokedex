using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pokedex.Models
{   

    public class Pokemon : ObservableObject
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

        [JsonProperty("abilities")]
        private List<Ability> _abilities;
        public List<Ability> Abilities
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
        private List<Stats> _statusBase;
        public List<Stats> StatusBase
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
        private Sprites _sprites;
        public Sprites Sprites
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

        [JsonProperty("types")]
        private List<TypeElement> _types;
        public List<TypeElement> Types
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
        private List<Move> _moves;
        public List<Move> Moves
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

        [JsonProperty("held_items")]
        private List<object> _heldItems;
        public List<object> HeldItems
        {
            get
            {
                return _heldItems;
            }
            set
            {
                SetProperty(ref _heldItems, value, nameof(HeldItems));
            }
        }

        [JsonProperty("is_default")]
        private bool _isDefault;
        public bool IsDefault
        {
            get
            {
                return _isDefault;
            }
            set
            {
                SetProperty(ref _isDefault, value, nameof(IsDefault));
            }
        }

        [JsonProperty("location_area_encounters")]
        public Uri _locationAreaEncounters;
        public Uri LocationAreaEncounters
        {
            get
            {
                return _locationAreaEncounters;
            }
            set
            {
                SetProperty(ref _locationAreaEncounters, value, nameof(LocationAreaEncounters));
            }
        }                    
        
    }

    #region Class Map Json

    public class Ability
    {
        [JsonProperty("ability")]
        public NameUrl PropertiesAbility { get; set; }

        [JsonProperty("is_hidden")]
        public bool? IsHidden { get; set; }

        [JsonProperty("slot")]
        public long? Slot { get; set; }
    }

    public class NameUrl
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public  class Move
    {
        [JsonProperty("move")]
        public NameUrl MoveMove { get; set; }
    }    
        
    public  class Sprites
    {       
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }

        [JsonProperty("front_shiny")]
        public Uri FrontShiny { get; set; }

        [JsonProperty("other")]
        public Other Other { get; set; }
    }    

    public class DreamWorld
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }
    }

    public class Other
    {
        [JsonProperty("dream_world")]
        public DreamWorld DreamWorld { get; set; }

        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public class OfficialArtwork
    {
        [JsonProperty("front_default")]
        public Uri FrontDefault { get; set; }
    }

    public class Stats
    {
        [JsonProperty("base_stat")]
        public long? ValueState { get; set; }

        [JsonProperty("effort")]
        public long? EffortState { get; set; }

        [JsonProperty("stat")]
        public NameUrl PropertiesState { get; set; }
    }

    public class TypeElement
    {
        [JsonProperty("slot")]
        public long? Slot { get; set; }

        [JsonProperty("type")]
        public NameUrl Type { get; set; }
    }

    public class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    #endregion 
}