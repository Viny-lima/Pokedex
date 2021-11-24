using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models
{
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

    }
}
