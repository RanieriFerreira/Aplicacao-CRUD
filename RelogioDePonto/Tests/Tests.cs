using System.Linq;
using Microsoft.EntityFrameworkCore;
using RelogioDePonto;
using RelogioDePonto.Applications;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using TestToolsToXunitProxy;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Get_BuscaTodosOsFuncionarios_True()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
                .UseInMemoryDatabase(databaseName: "Get_funcionarios")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new EmpresaContext(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 11111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 22222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 33333333333, Nome = "Funcionario 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var result = service.Get();
                Assert.AreEqual(3, result.Count());
            }
        }

        [TestMethod]
        public void Add_AdicionarFuncionario_True()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
               .UseInMemoryDatabase(databaseName: "Add_funcionario")
               .Options;

            // Run the test against one instance of the context
            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var funcionario = new Funcionario { Cpf = 11111111111, Nome = "Novo Funcionario" };
                service.Add(funcionario);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new EmpresaContext(options))
            {
                Assert.AreEqual(1, context.Funcionarios.Count());
                Assert.AreEqual("Novo Funcionario", context.Funcionarios.Single().Nome);
                Assert.AreEqual(11111111111, context.Funcionarios.Single().Cpf);
            }
        }

        [TestMethod]
        public void Add_AdicionarFuncionarioDuplicado_Exception()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
               .UseInMemoryDatabase(databaseName: "Add_funcionarios_iguais")
               .Options;

            // Run the test against one instance of the context
            using (var context = new EmpresaContext(options))
            {
                var service = new ApplicationFuncionario(context);
                var funcionario1 = new Funcionario { Cpf = 1111111111, Nome = "Novo Funcionario" };
                var funcionario2 = new Funcionario { Cpf = 1111111111, Nome = "Novo Funcionario" };
                service.Add(funcionario1);
                Assert.AreEqual("Erro: Esse CPF já esta sendo usado", service.Add(funcionario2));
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new EmpresaContext(options))
            {
                Assert.AreEqual(1, context.Funcionarios.Count());
            }
        }

        [TestMethod]
        public void GetOrderBy_BuscaOrdenadaComPaginacao_True()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
                .UseInMemoryDatabase(databaseName: "Get_funcionarios_pagina_ordenada")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new EmpresaContext(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 00000000000, Nome = "Funcionario 0" });
                context.Funcionarios.Add(new Funcionario { Cpf = 11111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 22222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 33333333333, Nome = "Funcionario 3" });
                context.Funcionarios.Add(new Funcionario { Cpf = 44444444444, Nome = "Funcionario 4" });
                context.Funcionarios.Add(new Funcionario { Cpf = 55555555555, Nome = "Funcionario 5" });
                context.Funcionarios.Add(new Funcionario { Cpf = 66666666666, Nome = "Funcionario 6" });
                context.Funcionarios.Add(new Funcionario { Cpf = 77777777777, Nome = "Funcionario 7" });
                context.Funcionarios.Add(new Funcionario { Cpf = 88888888888, Nome = "Funcionario 8" });
                context.Funcionarios.Add(new Funcionario { Cpf = 99999999999, Nome = "Funcionario 9" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new EmpresaContext(options))
            {
                var service = new ApplicationFuncionario(context);
                var result = service.GetOrderBy("Nome", 1, 4);
                Assert.AreEqual(4, result.Count());
            }
        }

        [TestMethod]
        public void Put_AtualizaDadoDoFuncionario_True()
        {
            var options = new DbContextOptionsBuilder<EmpresaContext>()
                .UseInMemoryDatabase(databaseName: "Put_funcionarios")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new EmpresaContext(options))
            {
                context.Funcionarios.Add(new Funcionario { Cpf = 11111111111, Nome = "Funcionario 1" });
                context.Funcionarios.Add(new Funcionario { Cpf = 22222222222, Nome = "Funcionario 2" });
                context.Funcionarios.Add(new Funcionario { Cpf = 33333333333, Nome = "Funcionario 3" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var funcionario = new Funcionario {Cpf = 11111111111, Nome = "Funcionario Modificado" };
                context.Update(funcionario);
                context.SaveChanges();
            }

            using (var context = new EmpresaContext(options))
            {
                var service = new FuncionarioRepositorio(context);
                var result = service.Get(11111111111);
                Assert.AreEqual("Funcionario Modificado", result.Nome);
            }
        }

        // TODO - Testar deleção de usuário


        //[TestMethod]
        //public void SPGetProjetos_BuscaProjetosLike_True()
        //{
        //    var options = new DbContextOptionsBuilder<EmpresaContext>()
        //        .UseInMemoryDatabase(databaseName: "Get_projetos_like")
        //        .Options;

        //    // Insert seed data into the database using one instance of the context
        //    using (var context = new EmpresaContext(options))
        //    {
        //        context.Projetos.Add(new Projeto { Nome = "Ifood",  Status = 0});
        //        context.Projetos.Add(new Projeto { Nome = "Banco virtual",  Status = 1});
        //        context.Projetos.Add(new Projeto { Nome = "Banco digital",  Status = 2});
        //        context.SaveChanges();
        //    }

        //    // Use a clean instance of the context to run the test
        //    using (var context = new EmpresaContext(options))
        //    {
        //        var projetos = context.Projetos.FromSql("EXEC dbo.GetProjetos @Nome = 'Banco'").ToList();
        //        Assert.AreEqual(2, projetos.Count());
        //    }
        //}
    }
}
