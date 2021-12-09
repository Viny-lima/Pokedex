using Pokedex.Model.Entities;
using System.Linq;

namespace Pokedex.Model.DAO
{
    internal class MoveDAO : PokedexDAO<MoveDB>
    {
        internal bool Exists(MoveDB moveDB)
        {
            var moves = FindAll().Result.Where(p => p.Name == moveDB.Name);

            return   moves.ToList().Count > 0;
        }
    }
}
