using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.DAO
{
    public interface IDAO<T> where T : class, IEntity
    {
        Task Add(T type);
        Task Update(T type);
        Task Delete(T type);
        Task<List<T>> FindAll();
    }
}
