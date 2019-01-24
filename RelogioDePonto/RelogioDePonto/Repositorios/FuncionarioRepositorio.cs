using Microsoft.AspNetCore.Mvc;
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
    public class FuncionarioRepositorio : Repositorio<Funcionario>, IFuncionarioRepositorio
    {
        private DbContext _context;
        public FuncionarioRepositorio (EmpresaContext context) : base(context)
        {
            _context = context;
        }
    }
}
