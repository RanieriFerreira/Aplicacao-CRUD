using Microsoft.EntityFrameworkCore;
using PagedList;
using RelogioDePonto.Models;
using RelogioDePonto.ModelsInput;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelogioDePonto.Applications
{
    public class ApplicationFuncionario
    {
        private RepositoryFuncionario _funcionarioRepositorio;
        private readonly DbContext _context;

        public ApplicationFuncionario(ContextEmpresa context)
        {
            _funcionarioRepositorio = new RepositoryFuncionario(context);
            _context = context;
        }

        public Funcionario Get(int Cpf)
        {
            if (Exists(Cpf))
            {
                return _funcionarioRepositorio.Get(Cpf);
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return null;
            }
        }

        public Funcionario GetByCpf(int Cpf)
        {
            if (Exists(Cpf))
            {
                return _funcionarioRepositorio.GetByCPF(Cpf);
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return null;
            }
        }

        public IQueryable<Funcionario> Get()
        {
            return _funcionarioRepositorio.Get();
        }

        public string Add(InputFuncionario inputFuncionario)
        {
            var funcionario = ToFuncionario(inputFuncionario);

            if (!Exists(funcionario.Cpf))
            {
                _funcionarioRepositorio.Add(funcionario);
                return funcionario.Cpf.ToString();
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return "Erro: Esse CPF já esta sendo usado";
            }
        }

        public IQueryable<Funcionario> GetPagedAndOrdered(string order, int page, int pageSize)
        {
            return _funcionarioRepositorio.PagedAndOrdered(order, page, pageSize);
        }

        public bool Exists(int cpf)
        {
            if (_funcionarioRepositorio.GetByCPF(cpf) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Remove(int cpf)
        {
            if (Exists(cpf))
            {
                var funcionario = _funcionarioRepositorio.GetByCPF(cpf);
                _funcionarioRepositorio.Remove(funcionario);
                return cpf.ToString();
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return "Erro: Esse funcionário não esta cadastrado no sistema";
            }
        }

        public void Put(InputFuncionario inputFuncionario)
        {
            var funcionario = ToFuncionario(inputFuncionario);

            if (Exists(inputFuncionario.Cpf))
            {
                _funcionarioRepositorio.Put(funcionario);
            }
            else
            {
                Add(inputFuncionario);
            }
        }

        public Funcionario ToFuncionario(InputFuncionario inputFuncionario)
        {
            return new Funcionario
            {
                Nome = inputFuncionario.Nome,
                Cpf = inputFuncionario.Cpf,
                Status = inputFuncionario.Status
            };
        }
    }
}
