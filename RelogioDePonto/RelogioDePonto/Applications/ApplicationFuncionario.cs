using Microsoft.EntityFrameworkCore;
using PagedList;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RelogioDePonto.Applications
{
    public class ApplicationFuncionario
    {
        private RepositoryFuncionario _funcionarioRepositorio;
        private DbContext _context;

        public ApplicationFuncionario(ContextEmpresa context)
        {
            _funcionarioRepositorio = new RepositoryFuncionario(context);
            _context = context;
        }

        public Funcionario Get(double Cpf)
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

        public IQueryable<Funcionario> Get()
        {
            return _funcionarioRepositorio.Get();
        }

        public string Add(Funcionario funcionario)
        {
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

        public bool Exists(double cpf)
        {
            if (_funcionarioRepositorio.Get(cpf) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Remove(Funcionario funcionario)
        {
            if (!Exists(funcionario.Cpf))
            {
                _funcionarioRepositorio.Remove(funcionario);
                return funcionario.Cpf.ToString();
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return "Erro: Esse funcionário não esta cadastrado no sistema";
            }
        }

        public void Put(Funcionario funcionario)
        {
            _funcionarioRepositorio.Put(funcionario);
        }
            
    }
}
