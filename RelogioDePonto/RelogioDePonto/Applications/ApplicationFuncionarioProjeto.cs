using CRUD_Empresa.Models;
using CRUD_Empresa.ViewsModels;
using CRUD_Empresa.repositories;
using Microsoft.AspNetCore.Mvc;
using RelogioDePonto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RelogioDePonto.Models;

namespace CRUD_Empresa.Applications
{
    public class ApplicationFuncionarioProjeto : ControllerBase
    {
        private RepositoryFuncionarioProjeto _projetoFuncionarioProjeto;
        private readonly ContextEmpresa _context;

        public ApplicationFuncionarioProjeto(ContextEmpresa context)
        {
            _projetoFuncionarioProjeto = new RepositoryFuncionarioProjeto(context);
            _context = context;
        }

        public ActionResult<FuncionarioProjeto> Get(int idFuncionario, int idProjeto)
        {
            return Ok(_projetoFuncionarioProjeto.Get(idFuncionario, idProjeto));
        }

        public ActionResult<FuncionarioProjeto> Get()
        {
            return Ok(_projetoFuncionarioProjeto.Get());
        }

        public ActionResult<FuncionarioProjeto> GetFuncionariosFromProjetos(int id)
        {
            return Ok(_projetoFuncionarioProjeto.GetFuncionariosFromProjeto(id));
        }

        public ActionResult<FuncionarioProjeto> GetProjetosFromFuncionario(int id)
        {
            return Ok(_projetoFuncionarioProjeto.GetProjetosFromFuncionario(id));
        }

        public ActionResult<Funcionario> Add(int idFuncionario, int idProjeto)
        {
            return Ok(_projetoFuncionarioProjeto.Add(idFuncionario, idProjeto));
        }

        public void Remove(int idFuncionario, int idProjeto) {
            _projetoFuncionarioProjeto.Remove(idFuncionario, idProjeto);
        }

        public bool Exists(int idFuncionario, int idProjeto)
        {
            if (_projetoFuncionarioProjeto.Get(idFuncionario, idProjeto) != null)
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
