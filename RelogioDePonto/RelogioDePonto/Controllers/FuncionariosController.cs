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
            return app.GetFuncionarios();
        }

        // GET: api/Funcionarios/5
        [HttpGet("{cpf}")]
        public ActionResult<Funcionario> GetFuncionario([FromRoute] int cpf)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var funcionario = await _context.Funcionarios.FindAsync(id);

            //if (funcionario == null)
            //{
            //    return NotFound();
            //}

            //return Ok(funcionario);
            var app = new Application(_context);
            return app.GetFuncionarioByCpf(cpf);
        }

        // PUT: api/Funcionarios/5
        [HttpPut("{cpf}")]
        public async Task<IActionResult> PutFuncionario([FromRoute] int cpf, [FromBody] Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cpf != funcionario.Cpf)
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
                if (!FuncionarioExists(cpf))
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
            app.AddFuncionario(funcionario);
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
        [HttpDelete("{cpf}")]
        public async Task<IActionResult> DeleteFuncionario([FromRoute] int cpf)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var funcionario = await _context.Funcionarios.FindAsync(cpf);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return Ok(funcionario);
        }

        private bool FuncionarioExists(int cpf)
        {
            return _context.Funcionarios.Any(e => e.Cpf == cpf);
        }
    }
}