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
        public FuncionarioRepositorio (EmpresaContext context) : base(context)
        {
        }

        public IEnumerable<Funcionario> PegaFuncionariosOrdenados()
        {
            var funcionarios = new List<Funcionario>();
            funcionarios.Add(new Funcionario(01234567980, "Funcionario 1"));
            funcionarios.Add(new Funcionario(01234567980, "Funcionario 2"));
            funcionarios.Add(new Funcionario(01234567980, "Funcionario 3"));
            funcionarios.Add(new Funcionario(01234567980, "Funcionario 4"));
            funcionarios.Add(new Funcionario(01234567980, "Funcionario 5"));
            return funcionarios;
            //return EmpresaContext.Funcionarios.OrderByDescending(c => c.Nome).Take(5).ToList();
        }

        public EmpresaContext EmpresaContext
        {
            get { return Context as EmpresaContext; }
        }
    }
}
