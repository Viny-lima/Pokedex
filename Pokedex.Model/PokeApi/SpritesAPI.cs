using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class SpritesAPI : ObservableObject
    {
        [JsonProperty("front_default")]
        private string _frontDefault;
        public string FrontDefault
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
        private string _frontShiny;
        public string FrontShiny
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
        private OtherAPI _other;
        public OtherAPI Other
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

}
