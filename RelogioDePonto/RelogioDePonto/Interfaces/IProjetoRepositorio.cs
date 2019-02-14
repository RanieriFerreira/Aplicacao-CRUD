using RelogioDePonto.Models;
using System.Linq;

namespace RelogioDePonto.Interfaces
{
    public interface IProjetoRepositorio : IRepositorio<Projeto>
    {
        IQueryable<Projeto> Search(string nome);
        int Put(int id, Projeto projeto);
    }
}
