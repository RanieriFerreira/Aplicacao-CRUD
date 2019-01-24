using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto;
using RelogioDePonto.Applications;
using RelogioDePonto.Modelos;

namespace RelogioDePonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private ApplicationFuncionario _applicationFuncionario;

        public FuncionariosController(EmpresaContext context)
        {
            _applicationFuncionario = new ApplicationFuncionario(context);
        }

        // GET: api/Funcionarios
        [HttpGet]
        public IEnumerable<Funcionario> Get()
        {
            return _applicationFuncionario.Get();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{cpf}")]
        public Funcionario Get([FromRoute] int cpf)
        {
            return _applicationFuncionario.Get(cpf);
        }

        // GET: api/Funcionarios/Nome/5/1
        [HttpGet("/pag/{order}/{number}/{size}")]
        public IEnumerable<Funcionario> GetPagedAndOrdered([FromRoute]string order, int size, int number)
        {
            return _applicationFuncionario.GetOrderBy(order, size, number);
        }

        // POST: api/Funcionarios
        [HttpPost]
        public void Post([FromBody] Funcionario entity)
        {
            _applicationFuncionario.Add(entity);
        }

        // PUT: api/Funcionarios/5
        [HttpPut("{cpf}")]
        public void Put([FromRoute] int cpf, [FromBody] Funcionario entity)
        {
        }

        // DELETE: api/Funcionarios/5
        [HttpDelete("{cpf}")]
        public void Delete([FromRoute] int cpf, [FromBody] Funcionario entity)
        {
            _applicationFuncionario.Remove(entity);
        }
    }
}