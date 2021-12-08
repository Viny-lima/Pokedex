using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.DAO
{
    internal class AbilityDAO : PokedexDAO<AbilityDB>
    {
        internal bool Exists(AbilityDB abilityDB)
        {
            var abilities = FindAll().Result.Where(p => p.Name == abilityDB.Name);

            return   abilities.ToList().Count > 0;
        }
    }
}
