using Pokedex.Model.Entities;
using Pokedex.Model.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Model.Service
{
    public interface IPokemonService<T> where T : class, IEntity
    {
        Task RegisterIsCreatedByUser(T pokemon);
        Task Update(T pokemon);
        Task Delete(T pokemon);
        Task<IList<T>> FindAllById(int start, int quantity);
        Task<IList<T>> FindAllByType(TypeNames typeName, int start, int quantity);
        Task<T> FindByName(string name);
        Task<T> FindById(int id);
    }
}
