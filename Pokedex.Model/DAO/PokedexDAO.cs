using Microsoft.EntityFrameworkCore;
using Pokedex.Model.Connection;
using Pokedex.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Model.DAO
{
    public abstract class PokedexDAO<T> : IDAO<T> where T : class, IEntity
    {
        public virtual async Task Add(T entity)
        {
            PokedexContext context = new PokedexContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task Update(T entity)
        {
            PokedexContext context = new PokedexContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task Delete(T entity)
        {
            PokedexContext context = new PokedexContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async virtual Task<List<T>> FindAll()
        {
            PokedexContext context = new PokedexContext();

            var list = await context.Set<T>().ToListAsync();

            return list;
        }

    }
}
