using System.Linq;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto;
using RelogioDePonto.Applications;
using RelogioDePonto.Models;
using RelogioDePonto.Repositorios;
using TestToolsToXunitProxy;

namespace Tests.RelogioDePonto
{
    [TestClass]
    public class TestsFuncionarios
    {
        [TestMethod]
        public void Get_BuscaTodosOsFuncionarios_True()
        {
            var options = new DbContextOptionsBuilder<ContextEmpresa>()
                .UseInMemoryDatabase(databaseName: "Get_funcionarios")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ContextEmpresa(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 333333333, Nome = "Funcionario 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ContextEmpresa(options))
            {
                var service = new RepositoryFuncionario(context);
                var result = service.Get();
                //Assert.AreEqual(3, result.Count());
            }
        }

        [TestMethod]
        public void Add_AdicionarFuncionario_True()
        {
            var options = new DbContextOptionsBuilder<ContextEmpresa>()
               .UseInMemoryDatabase(databaseName: "Add_funcionario")
               .Options;

            // Run the test against one instance of the context
            using (var context = new ContextEmpresa(options))
            {
                var service = new RepositoryFuncionario(context);
                var funcionario = new Funcionario { Cpf = 111111111, Nome = "Novo Funcionario" };
                service.Add(funcionario);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new ContextEmpresa(options))
            {
                Assert.AreEqual(1, context.Funcionarios.Count());
                Assert.AreEqual("Novo Funcionario", context.Funcionarios.Single().Nome);
                //Assert.AreEqual(111111111, context.Funcionarios.Single().Cpf);
            }
        }

        [TestMethod]
        public void GetOrderBy_BuscaOrdenadaComPaginacao_True()
        {
            var options = new DbContextOptionsBuilder<ContextEmpresa>()
                .UseInMemoryDatabase(databaseName: "Get_funcionarios_pagina_ordenada")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ContextEmpresa(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 000000000, Nome = "Funcionario 0" });
                context.Funcionarios.Add(new Funcionario { Cpf = 111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 333333333, Nome = "Funcionario 3" });
                context.Funcionarios.Add(new Funcionario { Cpf = 444444444, Nome = "Funcionario 4" });
                context.Funcionarios.Add(new Funcionario { Cpf = 555555555, Nome = "Funcionario 5" });
                context.Funcionarios.Add(new Funcionario { Cpf = 666666666, Nome = "Funcionario 6" });
                context.Funcionarios.Add(new Funcionario { Cpf = 777777777, Nome = "Funcionario 7" });
                context.Funcionarios.Add(new Funcionario { Cpf = 888888888, Nome = "Funcionario 8" });
                context.Funcionarios.Add(new Funcionario { Cpf = 999999999, Nome = "Funcionario 9" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ContextEmpresa(options))
            {
                var service = new ApplicationFuncionario(context);
                var result = service.GetPagedAndOrdered("Nome", 1, 4);
                //Assert.AreEqual(4, result.Count());
            }
        }

        [TestMethod]
        public void Put_AtualizaDadoDoFuncionario_True()
        {
            var options = new DbContextOptionsBuilder<ContextEmpresa>()
                .UseInMemoryDatabase(databaseName: "Put_funcionarios")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new ContextEmpresa(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 333333333, Nome = "Funcionario 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new ContextEmpresa(options))
            {
                var service = new RepositoryFuncionario(context);
                var funcionario = new Funcionario {Cpf = 111111111, Nome = "Funcionario Modificado" };
                service.Put(funcionario);
            }

            using (var context = new ContextEmpresa(options))
            {
                var service = new RepositoryFuncionario(context);
                var result = service.GetByCPF(111111111);
                //Assert.AreEqual("Funcionario Modificado", result.Nome);
            }
        }
    }
}
