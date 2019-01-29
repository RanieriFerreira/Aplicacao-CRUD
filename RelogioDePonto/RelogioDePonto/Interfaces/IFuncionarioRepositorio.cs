using RelogioDePonto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Interfaces
{
    public interface IFuncionarioRepositorio : IRepositorio<Funcionario>
    {
        IQueryable<Funcionario> PagedAndOrdered(string order, int page, int pageSize);
    }
}
