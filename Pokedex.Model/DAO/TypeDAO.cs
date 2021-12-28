using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.DAO
{
    internal class TypeDAO : PokedexDAO<TypeDB>
    {
        internal bool Exists(TypeDB typeDB)
        {
            var types = FindAll().Result.Where(p => p.Name == typeDB.Name);

            return   types.ToList().Count > 0;
        }

        internal async Task<TypeDB> FindByName(string name)
        {
            PokedexContext context = new PokedexContext();

            var type = await context.Types
                                    .FirstOrDefaultAsync(t => t.Name == name);

            return type;
        }
    }
}
