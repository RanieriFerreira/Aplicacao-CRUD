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

        // GET: api/ControllerFuncionarioProjeto/funcionario/5
        /// <summary>
        ///     Busca todos os projetos que um funcionário esta trabalhando
        /// </summary>
        /// <param name="idFuncionario">ID do funcionário alvo</param>
        /// <returns>Retorna os funcionários que trabalham no projeto.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet("funcionario/{idFuncionario}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<FuncionarioProjeto> GetProjetosFromFuncionario([FromRoute] int idFuncionario)
        {
            return _applicationFuncionarioProjeto.GetProjetosFromFuncionario(idFuncionario);
        }

        // GET: api/ControllerFuncionarioProjeto/projeto/5
        /// <summary>
        ///     Busca todos os funcionários de um projeto
        /// </summary>
        /// <param name="idProjeto">ID do projeto alvo</param>
        /// <returns>Retorna os projetos que o funcionários esta trabalhando.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet("projeto/{idProjeto}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<FuncionarioProjeto> GetFuncionariosFromProjetos([FromRoute] int idProjeto)
        {
            return _applicationFuncionarioProjeto.GetFuncionariosFromProjetos(idProjeto);
        }

        // POST: api/ControllerFuncionarioProjeto
        /// <summary>
        ///     Relaciona um funcionário com um projeto.
        /// </summary>
        /// <param name="relacao">Relação que deseja realizar</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Relacao> Post([FromBody] Relacao relacao)
        {
            return _applicationFuncionarioProjeto.Add(relacao);
        }

        // DELETE: api/Funcionarios/5
        /// <summary>
        ///     Deleta a relação entre um funcionário e um projeto
        /// </summary>
        /// <param name="idFuncionario">CPF do funcionário que deseja deletar</param>
        /// <param name="idProjeto">CPF do funcionário que deseja deletar</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="404">Se não encontrar o funcionario</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpDelete("funcionario/{idFuncionario}/projeto/{idProjeto}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public void Delete([FromRoute] int idFuncionario, [FromRoute] int idProjeto)
        {
            _applicationFuncionarioProjeto.Remove(idFuncionario, idProjeto);
        }
    }
}
