using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RelogioDePonto.Applications;
using RelogioDePonto.Models;
using RelogioDePonto.ModelsInput;

namespace RelogioDePonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerProjetos : ControllerBase
    {
        private ApplicationProjeto _applicationProjeto;

        public ControllerProjetos(ContextEmpresa context)
        {
            _applicationProjeto = new ApplicationProjeto(context);
        }

        // POST: api/Projetos
        /// <summary>
        ///     Cria projeto.
        /// </summary>
        /// <remarks>
        ///     Os status de um projeto podem ser:
        ///      - 0 - Inativo
        ///      - 1 - Ativo
        ///      - 2 - Em espera
        ///      - 3 - Finalizado
        /// </remarks>
        /// <param name="projeto">Entidade que deseja criar</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Post([FromBody] InputProjeto projeto)
        {
            _applicationProjeto.Add(projeto);
        }

        // GET: api/Projetos
        /// <summary>
        ///     Busca todos os projetos.
        /// </summary>
        /// <returns>Retorna todos os projetos cadastrados no banco</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IQueryable<Projeto> Get()
        {
            return _applicationProjeto.Get();
        }

        // GET: api/Projetos/5
        /// <summary>
        ///     Busca projeto por Id.
        /// </summary>
        /// <param name="id">Id do projeto que deseja procurar</param>
        /// <returns>Retorna o projeto cadastrados no banco, cujo Id é igual ao que foi passado.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public Projeto Get([FromRoute]int id)
        {
            return _applicationProjeto.Get(id);
        }

        // GET: api/Projetos/<nome projeto>
        /// <summary>
        ///     Busca projetos pelo nome.
        /// </summary>
        /// <remarks>
        ///     Busca todos os projetos, cujo nome, começam com o parametro passado.
        /// </remarks>
        /// <param name="nome">Inicio do nome de um projeto que deseja buscar</param>
        /// <returns>Retorna todos os projetos cadastrados no banco com o inicio do nomecorrespondente ao que foi passado.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet("search/{nome}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IQueryable<Projeto> Search([FromRoute]string nome)
        {
            return _applicationProjeto.Search(nome);
        }

        // PUT: api/Projetos/5
        /// <summary>
        ///     Atualiza ou cria projeto.
        /// </summary>
        /// <remarks>
        ///     Tenta alterar um projeto com o ID passado, se não existir um novo projeto é criado.
        /// </remarks>
        /// <param name="id">ID do projeto que deseja modificar</param>
        /// <param name="projeto">Projeto com os dados alterados</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public void Put([FromRoute] int id, [FromBody] InputProjeto projeto)
        {
            _applicationProjeto.Put(id, projeto);
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        ///     Deleta o projeto com o mesmo Id que foi passado.
        /// </summary>
        /// <param name="id">Id do projeto que deseja deletar</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public string Delete([FromRoute] int id)
        {
            return _applicationProjeto.Remove(id);
        }
    }
}
