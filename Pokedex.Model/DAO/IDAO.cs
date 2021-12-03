using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.DAO
{
    public interface IDAO<T> where T : IEntity
    {
        void Add(T type);
        void Update(T type);
        void Delete(T type);
        IList<T> FindAll();
    }
}
