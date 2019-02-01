using CRUD_Empresa.Interfaces;
using CRUD_Empresa.Models;
using CRUD_Empresa.ModelsInput;
using RelogioDePonto;
using RelogioDePonto.Repositories;
using System.Linq;

namespace CRUD_Empresa.repositories
{
    public class RepositoryFuncionarioProjeto : Repository<FuncionarioProjeto>, IFuncionarioProjetoRepositorio
    {
        private ContextEmpresa _context;
        public RepositoryFuncionarioProjeto(ContextEmpresa context) : base(context)
        {
            _context = context;
        }

        public IQueryable<OutputCountFuncionarioProjeto> CountFuncionariosProjeto(int id)
        {
            return null;
            //return _context.Set<OutputCountFuncionarioProjeto>().FromSql("CountFuncionariosProjeto @p0", id);
        }

        public IQueryable<OutputFuncionarioProjeto> GetFuncionariosProjeto(int id)
        {
            return null;
            //return _context.Set<OutputFuncionarioProjeto>().FromSql("GetFuncionariosProjeto @p0", id);
        }
    }
}
