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
        private readonly DbContext _context;

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

        public bool Exists(int id)
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

        public void Remove(int id)
        {
            // Verificar se o Projeto existe
            _projetoRepositorio.Remove(id);
        }

        public void Put(InputProjeto inputProjeto)
        {
            _projetoRepositorio.Put(ToProjeto(inputProjeto));
        }

        public Projeto ToProjeto(InputProjeto inputProjeto)
        {
            return new Projeto
            {
                Nome = inputProjeto.Nome,
                Detalhe = inputProjeto.Detalhe,
                Status = inputProjeto.Status
            };
        }
    }
}
