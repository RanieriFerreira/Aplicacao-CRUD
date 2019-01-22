using RelogioDePonto.Interfaces;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Repositorios
{
    public class FuncionarioRepositorio : Repositorio<Funcionario>
    {
        //public FuncionarioRepositorio (EmpresaContext context) : base(context)
        //{
        //}

        public string BuscaMock()
        {
            return "Mock1";
        }

        public EmpresaContext EmpresaContext
        {
            get { return Context as EmpresaContext; }
        }
    }
}
