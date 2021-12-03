using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace Pokedex.Model.PokeApi
{
    public class OtherAPI : ObservableObject
    {
        [JsonProperty("dream_world")]
        private DreamWorldAPI _dreamWorld;
        public DreamWorldAPI DreamWorld
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
        private OfficialArtworkAPI _officialArtwork;
        public OfficialArtworkAPI OfficialArtwork
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

}
