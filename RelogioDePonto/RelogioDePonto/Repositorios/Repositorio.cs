using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RelogioDePonto.Repositories
{

    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected DbContext Context;

        public Repositorio(DbContext context)
        {
            Context = context;
        }

        // Grupo para recuperar dados
        public T Get(double id)
        {
            return Context.Set<T>().Find(id);
        }
        public IQueryable<T> Get()
        {
            return Context.Set<T>();
        }

        // Grupo para adicionar
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Save();
        }

        // Grupo para deletar
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        // Grupo para salvar
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
