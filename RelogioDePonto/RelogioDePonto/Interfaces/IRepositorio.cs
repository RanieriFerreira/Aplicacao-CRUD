using System.Linq;

namespace RelogioDePonto.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        // Grupo para buscar
        T Get(int id);
        IQueryable<T> Get();

        // Grupo para adicionar
        void Add(T entity);

        // Grupo para salvar
        void Save();

        // Grupo para deletar
        void Remove(T entity);
    }
}
