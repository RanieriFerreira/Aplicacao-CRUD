using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RelogioDePonto.Applications;
using RelogioDePonto.Modelos;

namespace RelogioDePonto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private ApplicationProjeto _applicationProjeto;

        public ProjetosController(EmpresaContext context)
        {
            _applicationProjeto = new ApplicationProjeto(context);
        }

        // GET: api/Projeto
        [HttpGet]
        public IEnumerable<Projeto> Get()
        {
            return _applicationProjeto.Get();
        }

        // GET: api/Projeto/5
        [HttpGet("{id}")]
        public Projeto Get([FromRoute]int id)
        {
            return _applicationProjeto.Get(id);
        }

        // POST: api/Projeto
        [HttpPost]
        public void Post([FromBody] Projeto entity)
        {
            _applicationProjeto.Add(entity);
        }

        // PUT: api/Projeto/5
        [HttpPut("{id}")]
        public void Put([FromRoute] int id, [FromBody] Projeto entity)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id,[FromBody] Projeto entity)
        {
            _applicationProjeto.Remove(entity);
        }
    }
}
