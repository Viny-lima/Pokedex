using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokédex.Models
{
    public class Pokemon : ObservableObject
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
                this.SetProperty(ref this._sprite, value, nameof(Sprite));
            }
        }     

    }
}
