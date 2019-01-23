using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Applications
{
    public class ApplicationFuncionario
    {
        private FuncionarioRepositorio _funcionarioRepositorio;

        public ApplicationFuncionario(EmpresaContext context)
        {
            _funcionarioRepositorio = new FuncionarioRepositorio(context);
        }

        public Funcionario Get(int cpf)
        {
            return _funcionarioRepositorio.Get(cpf);
        }

        public IEnumerable<Funcionario> Get()
        {
            return _funcionarioRepositorio.Get();
        }

        public void Add(Funcionario entity)
        {
            _funcionarioRepositorio.Add(entity);
        }

        public void Save()
        {
            _funcionarioRepositorio.Save();
        }

        public void Remove(Funcionario entity)
        {
            // Verificar se o Projeto existe
            _funcionarioRepositorio.Remove(entity);
        }
    }
}
