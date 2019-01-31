using CRUD_Empresa.Models;
using RelogioDePonto;
using RelogioDePonto.Repositories;

namespace CRUD_Empresa.repositories
{
    public class RepositoryFuncionarioProjeto : Repository<FuncionarioProjeto>
    {
        private ContextEmpresa _context;
        public RepositoryFuncionarioProjeto(ContextEmpresa context) : base(context)
        {
            _context = context;
        }
    }
}
