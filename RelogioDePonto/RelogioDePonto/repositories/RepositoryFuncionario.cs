using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Models;
using RelogioDePonto.Repositories;

namespace RelogioDePonto.Repositorios
{
    public class RepositoryFuncionario : Repository<Funcionario>, IFuncionarioRepositorio
    {
        private DbContext _context;
        public RepositoryFuncionario (ContextEmpresa context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Funcionario> PagedAndOrdered(string order, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;

            switch (order)
            {
                case "nome_desc":
                    return _context.Set<Funcionario>().OrderByDescending(s => s.Nome).Skip(skip).Take(pageSize);
                case "Nome":
                    return _context.Set<Funcionario>().OrderBy(s => s.Nome).Skip(skip).Take(pageSize);
                case "status_desc":
                    return _context.Set<Funcionario>().OrderByDescending(s => s.Status).Skip(skip).Take(pageSize);
                default:
                    return _context.Set<Funcionario>().OrderBy(s => s.Status).Skip(skip).Take(pageSize);
            }
        }

        public void Put(Funcionario funcionario)
        {
            //var target = Get(funcionario.Cpf);

            //if (target != null)
            //{
                //target.Nome = funcionario.Nome;
                //target.Status = funcionario.Status;

                //_context.Update(target);
                //Save();
            //}
            //else
            //{
                Add(funcionario);
            //}
        }
    }
}
