using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class Other : ObservableObject
    {
        [Key]
        public int Id_Other { get; set; }

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

}
