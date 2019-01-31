using Microsoft.AspNetCore.Mvc;
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
    public class ApplicationProjeto : ControllerBase
    {
        private RepositoryProjeto _projetoRepositorio;
        private readonly DbContext _context;

        // Mensagens de retorno
        private string _msgProjetoNotFound = "Nenhum projeto encontrado";

        public ApplicationProjeto(ContextEmpresa context)
        {
            _projetoRepositorio = new RepositoryProjeto(context);
            _context = context;
        }

        public ActionResult<Projeto> Get(int id)
        {
            if (Exists(id))
            {
                return Ok(_projetoRepositorio.Get(id));
            }
            else {
                return NotFound(_msgProjetoNotFound);
            }
        }

        public IQueryable<Projeto> Get()
        {
            return _projetoRepositorio.Get();
        }

        public IQueryable<Projeto> Search(string nome)
        {
            return _projetoRepositorio.Search(nome);
        }

        public ActionResult<Projeto> Add(InputProjeto projeto)
        {
            var newProjeto = ToProjeto(projeto);
            _projetoRepositorio.Add(newProjeto);
            return Ok(newProjeto.Id);
        }

        public ActionResult<Projeto> Remove(int id)
        {
            if (Exists(id))
            {
                var projeto = _projetoRepositorio.Get(id);
                _projetoRepositorio.Remove(projeto);
                return NoContent();
            }
            else
            {
                return NotFound(_msgProjetoNotFound);
            }
        }

        public ActionResult<Projeto> Put(int id, InputProjeto inputProjeto)
        {
            if (Exists(id))
            {
                var projeto = ToProjeto(inputProjeto);
                _projetoRepositorio.Put(id, projeto);
                return Ok(projeto.Id);
            }
            else
            {
                return NotFound(_msgProjetoNotFound);
            }
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
