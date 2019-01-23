using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public IEnumerable<T> Get()
        {
            return Context.Set<T>().ToList();
        }

        // Grupo para adicionar
        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        // Grupo para deletar
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        // Grupo para salvar
        public void Save(T entity)
        {
            throw new NotImplementedException();
        }

        //public void Dispose()
        //{
        //    if (_context != null)
        //    {
        //        _context.Dispose();
        //    }
        //    GC.SuppressFinalize(this);
        //}

        //public IQueryable<FuncionarioRepositorio> Query(Expression<Func<FuncionarioRepositorio, bool>> filter)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
