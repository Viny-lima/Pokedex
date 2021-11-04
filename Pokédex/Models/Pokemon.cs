using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models
{
    public class Pokemon 
    {
        private string _sprite;
        public string Sprite 
        {
            get 
            {
                return _sprite;
            }
            set 
            {
                _sprite = value;
            }
        }     

    }
}
