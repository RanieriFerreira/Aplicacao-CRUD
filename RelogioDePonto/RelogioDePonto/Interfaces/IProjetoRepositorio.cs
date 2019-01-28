using RelogioDePonto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Interfaces
{
    public interface IProjetoRepositorio : IRepositorio<Projeto>
    {
        IEnumerable<Projeto> Get(string nome);
    }
}
