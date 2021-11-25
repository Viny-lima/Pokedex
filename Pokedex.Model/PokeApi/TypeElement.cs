using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.PokeApi
{
    public class TypeElement : ObservableObject
    {
        [Key]
        public int Id_TypeElement { get; set; }

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
        private PropertiesAbility _type;
        public PropertiesAbility Type
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

}
