using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Interfaces;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Applications
{
    public class ApplicationProjeto
    {
        private ProjetoRepositorio _projetoRepositorio;
        private DbContext _context;

        public ApplicationProjeto(EmpresaContext context)
        {
            _projetoRepositorio = new ProjetoRepositorio(context);
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

        public void Add(Projeto projeto)
        {
            _projetoRepositorio.Add(projeto);
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

        public void Save()
        {
            _projetoRepositorio.Save();
        }

        public void Remove(Projeto projeto)
        {
            // Verificar se o Projeto existe
            _projetoRepositorio.Remove(projeto);
        }

        public void Put(Projeto projeto)
        {
            if (!Exists(projeto.Id))
            {
                _projetoRepositorio.Add(projeto);
            }
            else
            {
                _context.Update(projeto);
            }
            Save();
        }
    }
}
