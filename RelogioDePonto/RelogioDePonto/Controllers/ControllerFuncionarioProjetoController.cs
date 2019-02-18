using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Empresa.Applications;
using CRUD_Empresa.Models;
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
        [HttpGet("projeto/{idFuncionario}")]
        public ActionResult<FuncionarioProjeto> GetProjetosFromFuncionario([FromRoute] int idFuncionario)
        {
            return _applicationFuncionarioProjeto.GetProjetosFromFuncionario(idFuncionario);
        }

        // GET: api/ControllerFuncionarioProjeto/5
        [HttpGet("funcionario/{idProjeto}")]
        public ActionResult<FuncionarioProjeto> GetFuncionariosFromProjetos([FromRoute] int idProjeto)
        {
            return _applicationFuncionarioProjeto.GetFuncionariosFromProjetos(idProjeto);
        }

        // POST: api/ControllerFuncionarioProjeto
        [HttpPost]
        public void Post([FromForm] int idFuncionario, [FromForm] int idProjeto)
        {
            _applicationFuncionarioProjeto.Add(idFuncionario, idProjeto);
        }

        [HttpDelete("{idFuncionario}/{idProjeto}")]
        public void Delete([FromRoute] int idFuncionario, [FromRoute] int idProjeto)
        {
            _applicationFuncionarioProjeto.Remove(idFuncionario, idProjeto);
        }
    }
}
