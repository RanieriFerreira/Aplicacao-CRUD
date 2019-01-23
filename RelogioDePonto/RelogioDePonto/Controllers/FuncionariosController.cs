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
        private readonly EmpresaContext _context;

        public FuncionariosController(EmpresaContext context)
        {
            _context = context;
        }

        // GET: api/Funcionarios
        [HttpGet]
        public IEnumerable<Funcionario> GetFuncionarios()
        {
            var app = new Application(_context);
            return app.Get();
            //var app = new Application(_context);
            //return app.BuscaTodos();
            ////var funcionarios = new List<Funcionario>();
            ////var funcionario = new Funcionario();
            ////funcionario.Nome = "Funcionario 1";
            ////funcionario.Cpf = 01234657890;
            ////funcionarios.Add(funcionario);
            ////return funcionarios;

            ////return _context.Funcionarios;
        }

        // GET: api/Funcionarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);

        }

        // PUT: api/Funcionarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncionario([FromRoute] int id, [FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionario.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(funcionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Funcionarios
        [HttpPost]
        public void PostFuncionario([FromBody] Funcionario funcionario)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //_context.Funcionarios.Add(funcionario);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFuncionario", new { id = funcionario.Cpf }, funcionario);

            var app = new Application(_context);
            app.Add();
        }
        //public async Task<IActionResult> PostFuncionario([FromBody] Funcionario funcionario)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //_context.Funcionarios.Add(funcionario);
        //    //await _context.SaveChangesAsync();

        //    //return CreatedAtAction("GetFuncionario", new { id = funcionario.Cpf }, funcionario);

        //    var app = new Application(_context);
        //    return app.Add();
        //}

        // DELETE: api/Funcionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncionario([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return Ok(funcionario);
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Cpf == id);
        }
    }
}