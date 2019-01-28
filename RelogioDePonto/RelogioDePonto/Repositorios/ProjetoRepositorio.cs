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
        private DbContext _context;
        public ProjetoRepositorio(EmpresaContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Projeto> Get(string nome)
        {
            return _context.FromSql("GetProjetos @p0", nome).ToList(); ;
        }
    }
}
