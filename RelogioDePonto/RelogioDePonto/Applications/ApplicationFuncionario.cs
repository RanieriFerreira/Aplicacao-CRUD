using Microsoft.AspNetCore.Mvc;
using PagedList;
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
            if (Exists(cpf))
            {
                return _funcionarioRepositorio.Get(cpf);
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return null;
            }
        }

        public IEnumerable<Funcionario> Get()
        {
            return _funcionarioRepositorio.Get();
        }

        public string Add(Funcionario funcionario)
        {
            if (!Exists(funcionario.Cpf))
            {
                _funcionarioRepositorio.Add(funcionario);
                Save();
                return funcionario.Cpf.ToString();
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return "Erro: Esse CPF já esta sendo usado";
            }
        }

        public IEnumerable<Funcionario> Paged(int number, int size, IEnumerable<Funcionario> funcionarios)
        {
            return funcionarios.ToPagedList(number, size);
        }

        public IEnumerable<Funcionario> GetOrderBy(string ordenadoPor, int number, int size)
        {
            IEnumerable<Funcionario> funcionarios = Get();
            
            switch (ordenadoPor)
            {
                case "nome_desc":
                    funcionarios = funcionarios.OrderByDescending(s => s.Nome);
                    break;
                case "Nome":
                    funcionarios = funcionarios.OrderBy(s => s.Nome);
                    break;
                case "status_desc":
                    funcionarios = funcionarios.OrderByDescending(s => s.Status);
                    break;
                default:
                    funcionarios = funcionarios.OrderBy(s => s.Status);
                    break;
            }

            return Paged(number, size, funcionarios);
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

        public string Remove(Funcionario funcionario)
        {
            if (!Exists(funcionario.Cpf))
            {
                // Verificar se o Projeto existe
                _funcionarioRepositorio.Remove(funcionario);
                return funcionario.Cpf.ToString();
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return "Erro: Esse funcionário não esta cadastrado no sistema";
            }
        }
    }
}
