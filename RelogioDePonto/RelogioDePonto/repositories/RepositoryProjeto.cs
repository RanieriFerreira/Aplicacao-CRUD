using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Repositorios
{
    public class RepositoryProjeto : Repository<Projeto>, IProjetoRepositorio
    {
        private DbContext _context;
        public RepositoryProjeto(ContextEmpresa context) : base(context)
        {
            _context = context;
        }

        public Projeto Get(int id)
        {
            return Context.Set<Projeto>().Find(id);
        }

        public IQueryable<Projeto> Search(string nome)
        {
            return _context.Set<Projeto>().FromSql("GetProjetos @p0", nome);
        }

        public void Put(Projeto projeto)
        {
            var target = Get(projeto.Id);

            if (target != null)
            {
                target.Nome = projeto.Nome;
                target.Detalhe = projeto.Detalhe;
                target.Status = projeto.Status;

                _context.Update(target);
                Save();
            }
            else
            {
                Add(projeto);
            }
        }
    }
}
