﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Model.DAO
{
    public abstract class PokedexDAO<T> : IDAO<T>
    {
        public void Add(T type)
        {
            throw new NotImplementedException();
        }

        public void Update(T type)
        {
            throw new NotImplementedException();
        }

        public void Delete(T type)
        {
            throw new NotImplementedException();
        }

        public IList<T> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
