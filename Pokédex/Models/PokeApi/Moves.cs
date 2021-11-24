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
    public class Moves : ObservableObject
    {
        [Key]
        public int Id_Moves { get; set; }

        [JsonProperty("move")]
        private PropertiesMove _move;
        public PropertiesMove Move
        {
            get
            {
                return _move;
            }
            set
            {
                SetProperty(ref _move, value);
            }
        }
    }

}
