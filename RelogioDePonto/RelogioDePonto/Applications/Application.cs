using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Applications
{
    public class Application
    {
        private readonly EmpresaContext _context;

        public Application(EmpresaContext context)
        {
            _context = context;
        }

        //public string BuscaTodos()
        //{
        //    var resposta =  new FuncionarioRepositorio(_context);
        //    return resposta.BuscaMock();
        //}

        public IEnumerable<Funcionario> GetFuncionarioOrdenados()
        {
            var func = new FuncionarioRepositorio(_context);
            return func.PegaFuncionariosOrdenados();
        }

        public void Add()
        {
            var funcionario = new Funcionario(01324567980, "Novo Funcionario");
            var func = new FuncionarioRepositorio(_context);
            func.Add(funcionario);
        }

        public IEnumerable<Funcionario> Get()
        {
            var func = new FuncionarioRepositorio(_context);
            return func.Get();
        }
    }
}
