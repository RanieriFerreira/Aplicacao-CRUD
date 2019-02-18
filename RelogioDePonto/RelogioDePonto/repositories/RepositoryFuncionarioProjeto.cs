using CRUD_Empresa.Interfaces;
using CRUD_Empresa.Models;
using CRUD_Empresa.ViewsModels;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto;
using RelogioDePonto.Models;
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


        public IQueryable<FuncionarioProjeto> Get()
        {   
            return _context.FuncionariosProjetos;
        }
        

        public FuncionarioProjeto Get(int idFuncionario, int idProjeto)
        {
            var targetFuncionariosProjetos = _context.FuncionariosProjetos
                    .Where(p => p.FuncionarioId == idFuncionario && p.ProjetoId == idProjeto)
                    .FirstOrDefault();

            return targetFuncionariosProjetos;
        }

        public IQueryable<FuncionarioProjeto> GetFuncionariosFromProjeto(int id)
        {
            return from fp in _context.FuncionariosProjetos
                   from p in _context.Projetos
                   where fp.ProjetoId == p.Id
                   select new FuncionarioProjeto
                   {
                       ProjetoId = fp.ProjetoId,
                       Funcionario = fp.Funcionario
                   };
        }

        public IQueryable<FuncionarioProjeto> GetProjetosFromFuncionario(int id)
        {
           return from fp in _context.FuncionariosProjetos
                  from f in _context.Funcionarios
                  where fp.FuncionarioId == f.Id
                  select new FuncionarioProjeto
                  {
                      FuncionarioId = f.Id,
                      Projeto = fp.Projeto
                  };
        }

        public FuncionarioProjeto Add(int idFuncionario, int idProjeto)
        {
            var targetFuncionario = _context.Funcionarios
                    .Include(p => p.ProjetosLink)
                    .Single(p => p.Id == idFuncionario);

            var newProjeto = _context.Projetos
                .Include(p => p.FuncionariosLink)
                .Single(p => p.Id == idProjeto);

            targetFuncionario.ProjetosLink.Add(new FuncionarioProjeto
            {
                FuncionarioId = targetFuncionario.Id,
                ProjetoId = newProjeto.Id,
                Funcionario = targetFuncionario,
                Projeto = newProjeto
            });

            Save();
            return targetFuncionario.ProjetosLink.Last();
        }

        public void Remove(int idFuncionario, int idProjeto)
        {
            var targetFuncionariosProjetos = _context.FuncionariosProjetos
                    .Where(p => p.FuncionarioId == idFuncionario && p.ProjetoId == idProjeto)
                    .FirstOrDefault();

            _context.Set<FuncionarioProjeto>().Remove(targetFuncionariosProjetos);

            Save();
        }
    }
}
