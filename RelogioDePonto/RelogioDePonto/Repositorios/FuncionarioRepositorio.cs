using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositories;

namespace RelogioDePonto.Repositorios
{
    public class FuncionarioRepositorio : Repositorio<Funcionario>, IFuncionarioRepositorio
    {
        private DbContext _context;
        public FuncionarioRepositorio (EmpresaContext context) : base(context)
        {
            _context = context;
        }
    }
}
