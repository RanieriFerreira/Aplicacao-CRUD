using Microsoft.AspNetCore.Mvc;
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

        public string Add(Funcionario funcionario)
        {
            /*
             *
             * existe funcionario com o cpf x
             *  caso exista retorna erro
             *  caso não exista adiciona e retorna informação de confirmação (ID ou CPF)
             */
            //_funcionarioRepositorio.Add(entity);
             
            if (!Exists(funcionario.Cpf))
            {
                _funcionarioRepositorio.Add(funcionario);
                Save();
                return funcionario.Cpf.ToString();
            }
            else
            {
                return "Erro: Esse CPF já esta sendo usado";
            }
        }

        public bool Exists(double cpf)
        {
            if (_funcionarioRepositorio.Get(cpf) != null)
            {
                return false;
            }
            else
            {
                return true;
            }
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
