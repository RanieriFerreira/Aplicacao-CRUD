using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using System.Linq;

namespace RelogioDePonto.Repositories
{

    public class Repository<T> : IRepositorio<T> where T : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        // Grupo para recuperar dados
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        // Grupo para adicionar
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        // Grupo para deletar
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            Save();
        }

        // Grupo para salvar
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
