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

    public class Ability : ObservableObject
    {

        [JsonProperty("ability")]
        private NameUrl _propertiesAbility;
        public NameUrl PropertiesAbility
        {
            get
            {
                return _propertiesAbility;
            }
            set
            {
                SetProperty(ref _propertiesAbility, value, nameof(PropertiesAbility));
            }
        }

        [JsonProperty("is_hidden")]
        private bool _isHidden;
        public bool IsHidden
        {
            get
            {
                return _isHidden;
            }
            set
            {
                SetProperty(ref _isHidden, value, nameof(IsHidden));
            }
        }

        [JsonProperty("slot")]
        private long _slot;
        public long Slot
        {
            get
            {
                return _slot;
            }
            set
            {
                SetProperty(ref _slot, value, nameof(Slot));
            }
        }

    }

    public class NameUrl : ObservableObject
    {

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

        [JsonProperty("url")]
        private Uri _url;
        public Uri Url
        {
            get
            {
                return _url;
            }
            set
            {
                SetProperty(ref _url, value, nameof(Url));
            }
        }

    }

    public  class Move : ObservableObject
    {

        [JsonProperty("move")]
        private NameUrl _moves;
        public NameUrl Moves
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
        
    public  class Sprites : ObservableObject
    {

        [JsonProperty("front_default")]
        private Uri _frontDefault;
        public Uri FrontDefault
        {
            get
            {
                return _frontDefault;
            }
            set
            {
                SetProperty(ref _frontDefault, value, nameof(FrontDefault));
            }
        }

        [JsonProperty("front_shiny")]
        private Uri _frontShiny;
        public Uri FrontShiny
        {
            get
            {
                return _frontShiny;
            }
            set
            {
                SetProperty(ref _frontShiny, value, nameof(FrontShiny));
            }
        }

        [JsonProperty("other")]
        private Other _other;
        public Other Other
        {
            get
            {
                return _other;
            }
            set
            {
                SetProperty(ref _other, value, nameof(Other));
            }
        }

    }    

    public class DreamWorld : ObservableObject
    {

        [JsonProperty("front_default")]
        private Uri _frontDefault;
        public Uri FrontDefault
        {
            get
            {
                return _frontDefault;
            }
            set
            {
                SetProperty(ref _frontDefault, value, nameof(FrontDefault));
            }
        }

    }

    public class Other : ObservableObject
    {

        [JsonProperty("dream_world")]
        private DreamWorld _dreamWorld;
        public DreamWorld DreamWorld
        {
            get
            {
                return _dreamWorld;
            }
            set
            {
                SetProperty(ref _dreamWorld, value, nameof(DreamWorld));
            }
        }

        [JsonProperty("official-artwork")]
        private OfficialArtwork _officialArtwork;
        public OfficialArtwork OfficialArtwork
        {
            get
            {
                return _officialArtwork;
            }
            set
            {
                SetProperty(ref _officialArtwork, value, nameof(OfficialArtwork));
            }
        }

    }

    public class OfficialArtwork : ObservableObject
    {

        [JsonProperty("front_default")]
        private Uri _frontDefault;
        public Uri FrontDefault
        {
            get
            {
                return _frontDefault;
            }
            set
            {
                SetProperty(ref _frontDefault, value, nameof(FrontDefault));
            }
        }

    }

    public class Stats : ObservableObject
    {
        [JsonProperty("base_stat")]
        private long _valueState;
        public long ValueState
        {
            get
            {
                return _valueState;
            }
            set
            {
                SetProperty(ref _valueState, value, nameof(ValueState));
            }
        }

        [JsonProperty("effort")]
        private long _efforState;
        public long EffortState
        {
            get
            {
                return _efforState;
            }
            set
            {
                SetProperty(ref _efforState, value, nameof(EffortState));
            }
        }

        [JsonProperty("stat")]
        private NameUrl _propertiesState;
        public NameUrl PropertiesState
        {
            get
            {
                return _propertiesState;
            }
            set
            {
                SetProperty(ref _propertiesState, value, nameof(PropertiesState));
            }
        }

    }

    public class TypeElement : ObservableObject
    {
        [JsonProperty("slot")]
        private long _slot;
        public long Slot
        {
            get
            {
                return _slot;
            }
            set
            {
                SetProperty(ref _slot, value, nameof(Slot));
            }
        }

        [JsonProperty("type")]
        private NameUrl _type;
        public NameUrl Type
        {
            get
            {
                return _type;
            }
            set
            {
                SetProperty(ref _type, value, nameof(Type));
            }
        }

    }

    public class Species : ObservableObject
    {
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

        [JsonProperty("url")]
        private Uri _url;
        public Uri Url
        {
            get
            {
                return _url;
            }
            set
            {
                SetProperty(ref _url, value, nameof(Url));
            }
        }

    }

    #endregion 
}