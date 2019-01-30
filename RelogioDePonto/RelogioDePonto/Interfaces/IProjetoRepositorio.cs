using RelogioDePonto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Interfaces
{
    public interface IProjetoRepositorio : IRepositorio<Projeto>
    {
        IQueryable<Projeto> Search(string nome);
        void Put(int id, Projeto projeto);
    }
}
