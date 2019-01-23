using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Repositorios
{
    public class ProjetoRepositorio : Repositorio<Projeto>
    {
        public ProjetoRepositorio(EmpresaContext context) : base(context)
        {
        }
    }
}
