using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.DAO
{
    public interface IDAO<T>
    {
        void Add(T type);
        void Update(T type);
        void Delete(T type);
        IList<T> FindAll();
    }
}
