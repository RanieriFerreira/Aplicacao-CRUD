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

        // Funções do Funcionario
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            var funcionario = new FuncionarioRepositorio(_context);
            return funcionario.Get();
        }
        public Funcionario GetFuncionarioByCpf(int cpf)
        {
            var funcionario = new FuncionarioRepositorio(_context);
            return funcionario.Get(cpf);
        }
        public void AddFuncionario(Funcionario funcionario)
        {
            var funcionarioTeste = new Funcionario(01324567980, "Novo Funcionario");
            var func = new FuncionarioRepositorio(_context);
            func.Add(funcionarioTeste);
            func.Save();
        }
        public void RemoveFuncionario(Funcionario funcionario)
        {
            var funcionarioTeste = new Funcionario(01324567980, "Novo Funcionario");
            var func = new FuncionarioRepositorio(_context);
            func.Remove(funcionarioTeste);
        }

        // Funções da Empresa
            // TODO 
    }
}
