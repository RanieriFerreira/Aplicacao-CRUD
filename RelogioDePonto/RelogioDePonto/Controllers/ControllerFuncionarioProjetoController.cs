using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Empresa.Applications;
using CRUD_Empresa.Models;
using CRUD_Empresa.ViewsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelogioDePonto;
using RelogioDePonto.Models;

namespace CRUD_Empresa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerFuncionarioProjetoController : ControllerBase
    {
        private ApplicationFuncionarioProjeto _applicationFuncionarioProjeto;

        public ControllerFuncionarioProjetoController(ContextEmpresa context)
        {
            _applicationFuncionarioProjeto = new ApplicationFuncionarioProjeto(context);
        }

        [HttpGet]
        public ActionResult<FuncionarioProjeto> Get()
        {
            return _applicationFuncionarioProjeto.Get();
        }
     
        // GET: api/ControllerFuncionarioProjeto/5
        [HttpGet("funcionario/{idFuncionario}")]
        public ActionResult<FuncionarioProjeto> GetProjetosFromFuncionario([FromRoute] int idFuncionario)
        {
            return _applicationFuncionarioProjeto.GetProjetosFromFuncionario(idFuncionario);
        }

        // GET: api/ControllerFuncionarioProjeto/5
        [HttpGet("projeto/{idProjeto}")]
        public ActionResult<FuncionarioProjeto> GetFuncionariosFromProjetos([FromRoute] int idProjeto)
        {
            return _applicationFuncionarioProjeto.GetFuncionariosFromProjetos(idProjeto);
        }

        // POST: api/ControllerFuncionarioProjeto
        [HttpPost]
        public ActionResult<Relacao> Post([FromBody] Relacao relacao)
        {
            return _applicationFuncionarioProjeto.Add(relacao);
        }

        [HttpDelete("{idFuncionario}/{idProjeto}")]
        public void Delete([FromRoute] int idFuncionario, [FromRoute] int idProjeto)
        {
            _applicationFuncionarioProjeto.Remove(idFuncionario, idProjeto);
        }
    }
}
