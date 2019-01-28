﻿using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Repositorios
{
    public class ProjetoRepositorio : Repositorio<Projeto>, IProjetoRepositorio
    {
        private DbContext _context;
        public ProjetoRepositorio(EmpresaContext context) : base(context)
        {
            _context = context;
        }

        public Projeto Get(int id)
        {
            return Context.Set<Projeto>().Find(id);
        }

        public IEnumerable<Projeto> Get(string nome)
        {
            return _context.Set<Projeto>().FromSql("EXECUTE GetProjetos @p0", nome).ToList();
        }
    }
}
