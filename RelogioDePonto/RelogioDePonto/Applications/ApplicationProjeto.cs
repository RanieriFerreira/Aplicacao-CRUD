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
            if (_projetoRepositorio.Get(id) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Remove(int id)
        {
            if (Exists(id))
            {
                var projeto = _projetoRepositorio.Get(id);
                _projetoRepositorio.Remove(projeto);
                return id.ToString();
            }
            else
            {
                // TODO - Corrigir o tipo de retorno do erro
                return "Erro: Esse funcionário não esta cadastrado no sistema";
            }
        }

        public void Put(int id, InputProjeto inputProjeto)
        {
            var projeto = ToProjeto(inputProjeto);

            if (Exists(id))
            {
                _projetoRepositorio.Put(id, projeto);
            }
            else
            {
                Add(inputProjeto);
            }
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
