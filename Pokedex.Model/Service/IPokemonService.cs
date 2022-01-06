using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public interface IPokemonService<T> where T : class, IEntity
    {
        Task Add(T pokemon);
        Task Update(T pokemon);
        Task Delete(T pokemon);
        Task<IList<T>> FindAllById(int start, int quantity);
        Task<IList<T>> FindAllByType(string type, int start, int quantity);
        Task<T> FindByName(string name);
        Task<T> FindById(int id);
    }
}
