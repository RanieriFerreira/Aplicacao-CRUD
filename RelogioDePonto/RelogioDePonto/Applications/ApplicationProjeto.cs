using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Models;
using RelogioDePonto.ModelsInput;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Applications
{
    public class ApplicationProjeto
    {
        private RepositoryProjeto _projetoRepositorio;
        private DbContext _context;

        public ApplicationProjeto(ContextEmpresa context)
        {
            _projetoRepositorio = new RepositoryProjeto(context);
            _context = context;
        }

        public Projeto Get(int id)
        {
            return _projetoRepositorio.Get(id);
        }

        public IQueryable<Projeto> Get()
        {
            return _projetoRepositorio.Get();
        }

        public IQueryable<Projeto> Search(string nome)
        {
            return _projetoRepositorio.Search(nome);
        }

        public void Add(InputProjeto projeto)
        {
            _projetoRepositorio.Add(ToProjeto(projeto));
        }

        public bool Exists(double id)
        {
            if (_projetoRepositorio.Get(id) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Remove(Projeto projeto)
        {
            // Verificar se o Projeto existe
            _projetoRepositorio.Remove(projeto);
        }

        public void Put(InputProjeto projetoInput)
        {
            _projetoRepositorio.Put(ToProjeto(projetoInput));
        }

        public Projeto ToProjeto(InputProjeto projetoInput)
        {
            return new Projeto
            {
                Nome = projetoInput.Nome,
                Detalhe = projetoInput.Detalhe,
                Status = projetoInput.Status
            };
        }
    }
}
