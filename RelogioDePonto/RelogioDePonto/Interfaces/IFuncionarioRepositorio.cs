using RelogioDePonto.Models;
using System.Linq;

namespace RelogioDePonto.Interfaces
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {
        IQueryable<Funcionario> PagedAndOrdered(string order, int page, int pageSize);
        Funcionario GetByCPF(int cpf);
        void Put(Funcionario funcionario);
    }
}
