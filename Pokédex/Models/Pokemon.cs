using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pokedex.Models
{   

    public class Pokemon
    {

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public long? Height { get; set; }

        [JsonProperty("weight")]
        public long? Weight { get; set; }

        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; }

        [JsonProperty("base_experience")]
        public long? BaseExperience { get; set; }

        [JsonProperty("stats")]
        public List<Stats> StatusBase { get; set; }

        [JsonProperty("species")]
        public NameUrl Species { get; set; }

        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }

        [JsonProperty("types")]
        public List<TypeElement> Types { get; set; }

        [JsonProperty("moves")]
        public List<Move> Moves { get; set; }

        [JsonProperty("forms")]
        public List<NameUrl> Forms { get; set; }

        [JsonProperty("held_items")]
        public List<object> HeldItems { get; set; }        

        [JsonProperty("is_default")]
        public bool? IsDefault { get; set; }

        [JsonProperty("location_area_encounters")]
        public Uri LocationAreaEncounters { get; set; }                      
        
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