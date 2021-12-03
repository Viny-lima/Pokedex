using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.DAO
{
    public abstract class PokedexDAO<T> : IDAO<T>
    {
        public virtual void Add(T type)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T type)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T type)
        {
            throw new NotImplementedException();
        }

        public virtual IList<T> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
