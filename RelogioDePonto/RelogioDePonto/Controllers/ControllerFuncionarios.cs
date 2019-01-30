using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RelogioDePonto.Applications;
using RelogioDePonto.Models;
using RelogioDePonto.ModelsInput;

namespace RelogioDePonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerFuncionarios : ControllerBase
    {
        private ApplicationFuncionario _applicationFuncionario;

        public ControllerFuncionarios(ContextEmpresa context)
        {
            _applicationFuncionario = new ApplicationFuncionario(context);
        }

        // POST: api/Funcionarios
        /// <summary>
        ///     Cria funcionario.
        /// </summary>
        /// <remarks>
        ///     Os status de um funcionario podem ser:
        ///      - 0 - Inativo
        ///      - 1 - Ativo
        ///      - 2 - Férias
        ///      - 3 - Desligado
        /// </remarks>
        /// <param name="inputFuncionario">Entidade que deseja criar</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public void Post([FromBody] InputFuncionario inputFuncionario)
        {
            _applicationFuncionario.Add(inputFuncionario);
        }

        // GET: api/Funcionarios
        /// <summary>
        ///     Busca todos os funcionários.
        /// </summary>
        /// <returns>Retorna todos os funcionarios cadastrados no banco.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IQueryable<Funcionario> Get()
        {
            return _applicationFuncionario.Get();
        }

        // GET: api/Funcionarios/5
        /// <summary>
        ///     Busca funcionário por CPF.
        /// </summary>
        /// <param name="cpf">CPF do funcionário que deseja procurar.</param>
        /// <returns>Retorna o projeto cadastrados no banco, cujo Id é igual ao que foi passado.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public Funcionario Get([FromRoute] int cpf)
        {
            return _applicationFuncionario.GetByCpf(cpf);
        }

        // GET: api/Funcionarios/pag/<tipo de ordenação>/<pagina>/<tamanho>
        /// <summary>
        ///     Paginação de funcionários.
        /// </summary>
        /// <remarks>
        ///  Tipos de ordenação:
        ///     - Nome : Ordenação crescente por nome
        ///     - nome_desc: Ordenação decrescente por nome
        ///     - status_desc: Ordenação decrescente por status
        ///     - default: Ordenação crescente por status
        /// </remarks>
        /// <param name="order">Tipo de orderação</param>
        /// <param name="page">Número da página</param>
        /// <param name="pageSize">Quantidade de funcionários por página</param>
        /// <returns>Retorna os funcioários em paginas e ordenados.</returns>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="400">Parametros inválidos</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpGet("/pag/{order}/{page}/{pageSize}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IQueryable<Funcionario> GetPagedAndOrdered([FromRoute]string order, int page, int pageSize)
        {
            return _applicationFuncionario.GetPagedAndOrdered(order, page, pageSize);
        }

        // PUT: api/Funcionarios/5
        /// <summary>
        ///     Atualiza ou cria funcionario.
        /// </summary>
        /// <remarks>
        ///     Tenta alterar um funcionario com o CPF passado, se não existir um novo funcionario é criado.
        /// </remarks>
        /// <param name="funcionario">Funcionario com os dados alterados</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response> 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public void Put([FromBody] InputFuncionario funcionario)
        {
            _applicationFuncionario.Put(funcionario);
        }

        // DELETE: api/Funcionarios/5
        /// <summary>
        ///     Deleta o projeto com o mesmo Id que foi passado.
        /// </summary>
        /// <param name="cpf">CPF do funcionário que deseja deletar</param>
        /// <response code="200">Se a operação foi feita com sucesso</response>
        /// <response code="500">Problema de acesso ao servidor</response>  
        [HttpDelete("{cpf}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public string Delete([FromRoute] int cpf)
        {
           return  _applicationFuncionario.Remove(cpf);
        }
    }
}