using RelogioDePonto.Interfaces;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelogioDePonto.Applications
{
    public class ApplicationProjeto : IApplication<Projeto>
    {
        private ProjetoRepositorio _projetoRepositorio;

        public ApplicationProjeto(EmpresaContext context)
        {
            _projetoRepositorio = new ProjetoRepositorio(context);
        }

        public Projeto Get(int id)
        {
            return _projetoRepositorio.Get(id);
        }

        public IEnumerable<Projeto> Get()
        {
            return _projetoRepositorio.Get();
        }

        public IEnumerable<Projeto> Get(string nome)
        {
            return _projetoRepositorio.Get(nome);
        }

        public void Add(Projeto entity)
        {
            _projetoRepositorio.Add(entity);
        }

        public void Save()
        {
            _projetoRepositorio.Save();
        }

        public void Remove(Projeto entity)
        {
            // Verificar se o Projeto existe
            _projetoRepositorio.Remove(entity);
        }
    }
}
