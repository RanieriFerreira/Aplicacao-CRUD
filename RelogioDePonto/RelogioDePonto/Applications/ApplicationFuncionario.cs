using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto.Models;
using RelogioDePonto.ModelsInput;
using RelogioDePonto.Repositorios;
using System.Linq;

namespace RelogioDePonto.Applications
{
    public class ApplicationFuncionario : ControllerBase
    {
        private RepositoryFuncionario _funcionarioRepositorio;
        private readonly DbContext _context;

        // Mensagens de retorno
        private string _msgFuncionarioNotFound = "Nenhum funcionário encontrado com esse CPF";
        private string _msgCpfExists = "CPF já cadastrado";

        public ApplicationFuncionario(ContextEmpresa context)
        {
            _funcionarioRepositorio = new RepositoryFuncionario(context);
            _context = context;
        }

        public ActionResult<Funcionario> GetByCpf(int Cpf)
        {
            if (Exists(Cpf))
            {
                return Ok(_funcionarioRepositorio.GetByCPF(Cpf));
            }
            else
            {
                return NotFound(_msgFuncionarioNotFound);
            }
        }

        public IQueryable<Funcionario> Get()
        {
            return _funcionarioRepositorio.Get();
        }

        public ActionResult<Funcionario> Add(InputFuncionario inputFuncionario)
        {
            var funcionario = ToFuncionario(inputFuncionario);

            if (!Exists(funcionario.Cpf))
            {
                _funcionarioRepositorio.Add(funcionario);
                return Ok(funcionario);
            }
            else
            {
                return BadRequest(_msgCpfExists);
            }
        }

        public ActionResult<Funcionario> Remove(int cpf)
        {
            if (Exists(cpf))
            {
                var funcionario = _funcionarioRepositorio.GetByCPF(cpf);
                _funcionarioRepositorio.Remove(funcionario);
                return Ok(cpf.ToString());
            }
            else
            {
                return NotFound(_msgFuncionarioNotFound);
            }
        }

        public IQueryable<Funcionario> GetPagedAndOrdered(string order, int page, int pageSize)
        {
            return _funcionarioRepositorio.PagedAndOrdered(order, page, pageSize);
        }

        public ActionResult<Funcionario> Put(InputFuncionario inputFuncionario)
        {
            var funcionario = ToFuncionario(inputFuncionario);

            if (Exists(inputFuncionario.Cpf))
            {
                funcionario.Id=_funcionarioRepositorio.Put(funcionario);
                return Ok(funcionario);
            }
            else
            {
                return NotFound(_msgFuncionarioNotFound);
            }
        }

        public bool Exists(int cpf)
        {
            if (_funcionarioRepositorio.GetByCPF(cpf) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Funcionario ToFuncionario(InputFuncionario inputFuncionario)
        {
            return new Funcionario
            {
                Nome = inputFuncionario.Nome,
                Cpf = inputFuncionario.Cpf,
                Status = inputFuncionario.Status
            };
        }
    }
}
