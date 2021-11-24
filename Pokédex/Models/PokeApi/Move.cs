using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models.PokeApi
{
    public class Move : ObservableObject
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

}
