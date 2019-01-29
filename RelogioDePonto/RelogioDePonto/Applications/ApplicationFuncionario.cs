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
        private FuncionarioRepositorio _funcionarioRepositorio;
        private DbContext _context;

        public ApplicationFuncionario(EmpresaContext context)
        {
            _funcionarioRepositorio = new FuncionarioRepositorio(context);
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
                Save();
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

        public void Save()
        {
            _funcionarioRepositorio.Save();
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
            var entity = Get(funcionario.Cpf);

            // Validate entity is not null
            if (entity != null)
            {
                // Answer for question #2

                // Make changes on entity
                entity.Nome = funcionario.Nome;
                entity.Status = funcionario.Status;

                // Update entity in DbSet
                _context.Update(entity);
            }
            else
            {
                Add(funcionario);
            }
            Save();
        }
            
    }
}
