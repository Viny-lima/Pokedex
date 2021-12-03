using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.Interfaces
{
    interface ITypeDAO
    {
        void AddType(TypeDB typeDB);
        void RemoveType(TypeDB typeDB);
        void UpdateType(TypeDB typeDB);

    }
}
