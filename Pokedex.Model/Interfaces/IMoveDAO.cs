using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    interface IMoveDAO
    {
        void AddMove(MoveDB moveDB);
        void RemoveMove(MoveDB moveDB);
        void UpdateMove(MoveDB moveDB);
    }
}
