﻿using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Models;
using RelogioDePonto.Repositories;
using System.Linq;

namespace RelogioDePonto.Repositorios
{
    public class RepositoryProjeto : Repository<Projeto>, IProjetoRepositorio
    {
        private ContextEmpresa _context;
        public RepositoryProjeto(ContextEmpresa context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Projeto> Search(string nome)
        {
            return _context.Set<Projeto>().FromSql("GetProjetos @p0", nome);
        }

        public int Put(int id, Projeto projeto)
        {
            var target = Get(id);

            target.Nome = projeto.Nome;
            target.Detalhe = projeto.Detalhe;
            target.Status = projeto.Status;

            _context.Update(target);
            Save();
            return target.Id;
        }
    }
}
