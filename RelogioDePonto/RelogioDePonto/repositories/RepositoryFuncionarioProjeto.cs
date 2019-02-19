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
                   join p in _context.Projetos on fp.Projeto.Id equals p.Id
                   where (fp.ProjetoId == id)
                   select new FuncionarioProjeto
                   {
                       ProjetoId = fp.ProjetoId,
                       Funcionario = fp.Funcionario
                   };
        }

        public IQueryable<FuncionarioProjeto> GetProjetosFromFuncionario(int id)
        {
           return from fp in _context.FuncionariosProjetos
                  join f in _context.Funcionarios on fp.FuncionarioId equals f.Id
                  where (fp.FuncionarioId == id)
                  select new FuncionarioProjeto
                  {
                      FuncionarioId = f.Id,
                      Projeto = fp.Projeto
                  };
        }

        public Relacao Add(Relacao relacao)
        {
            var func = _context.Funcionarios.Find(relacao.idFuncionario);

            var targetFuncionario = _context.Funcionarios
                    .Include(p => p.ProjetosLink)
                    .Single(p => p.Id == relacao.idFuncionario);

            var newProjeto = _context.Projetos
                .Include(p => p.FuncionariosLink)
                .Single(p => p.Id == relacao.idProjeto);

            targetFuncionario.ProjetosLink.Add(new FuncionarioProjeto
            {
                FuncionarioId = targetFuncionario.Id,
                ProjetoId = newProjeto.Id,
                Funcionario = targetFuncionario,
                Projeto = newProjeto
            });

            Save();

            return relacao;
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
