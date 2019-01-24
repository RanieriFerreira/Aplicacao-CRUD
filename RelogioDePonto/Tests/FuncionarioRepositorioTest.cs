using System.Linq;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using TestToolsToXunitProxy;

namespace Tests
{
    [TestClass]
    public class FuncionarioRepositorioTest
    {
        [TestMethod]
        public void TesteDeBuscaDeUsuario()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
                .UseInMemoryDatabase(databaseName: "Get_funcionarios")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new EmpresaContext(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 333333333, Nome = "Funcionario 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var result = service.Get();
                Equals(3, result.Count());
            }
        }

        [TestMethod]
        public void TesteDeCriacaoDeUsuario()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
               .UseInMemoryDatabase(databaseName: "Add_funcionario")
               .Options;

            // Run the test against one instance of the context
            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var funcionario = new Funcionario { Cpf = 1111, Nome = "Novo Funcionario" };
                service.Add(funcionario);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new EmpresaContext(options))
            {
                Equals(1, context.Funcionarios.Count());
                Equals("Novo Funcionario", context.Funcionarios.Single().Nome);
                Equals(1111, context.Funcionarios.Single().Cpf);
            }
        }

        [TestMethod]
        public void TesteAddFuncionariosIguais()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
               .UseInMemoryDatabase(databaseName: "Add_funcionarios_iguais")
               .Options;

            // Run the test against one instance of the context
            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var funcionario1 = new Funcionario { Cpf = 1111, Nome = "Novo Funcionario" };
                var funcionario2 = new Funcionario { Cpf = 1111, Nome = "Novo Funcionario" };
                service.Add(funcionario1);
                service.Add(funcionario2);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new EmpresaContext(options))
            {
                Equals(2, context.Funcionarios.Count());
            }
        }
    }
}
