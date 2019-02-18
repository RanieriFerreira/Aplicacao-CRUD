using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Models;
using RelogioDePonto.ViewsModels;
using RelogioDePonto.Repositorios;
using System.Linq;
using AutoMapper;

namespace RelogioDePonto.Applications
{
    public class ApplicationProjeto : ControllerBase
    {
        private RepositoryProjeto _projetoRepositorio;
        private readonly ContextEmpresa _context;
        private readonly IMapper _mapper;

        // Mensagens de retorno
        private string _msgProjetoNotFound = "Nenhum projeto encontrado";

        public ApplicationProjeto(ContextEmpresa context, IMapper mapper)
        {
            _projetoRepositorio = new RepositoryProjeto(context);
            _context = context;
            _mapper = mapper; ;
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

        public ActionResult<Projeto> Add(ViewModelProjeto inputProjeto)
        {
            var newProjeto = _mapper.Map<ViewModelProjeto, Projeto>(inputProjeto);
            _projetoRepositorio.Add(newProjeto);
            return Ok(newProjeto);
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

        public ActionResult<Projeto> Put(int id, ViewModelProjeto inputProjeto)
        {
            if (Exists(id))
            {
                var projeto = _mapper.Map<ViewModelProjeto, Projeto>(inputProjeto);
                projeto.Id = _projetoRepositorio.Put(id, projeto);
                return Ok(projeto);
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
    }
}
