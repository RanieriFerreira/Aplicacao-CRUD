using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using RelogioDePonto;
using RelogioDePonto.Modelos;
using RelogioDePonto.Repositorios;
using Xunit;

namespace Tests
{
    public class FuncionarioRepositorioTest
    {
        [Fact]
        public void TesteDeBuscaDeUsuario()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory data
            IQueryable<Funcionario> funcionarios = new List<Funcionario>
            {
                new Funcionario(00000000000,"Funcionario 1"),
                new Funcionario(1111111111,"Funcionario 2")
            }.AsQueryable();

            // To query our database we need to implement IQueryable 
            var mockSet = new Mock<DbSet<Funcionario>>();
            //mockSet.As<IQueryable<Funcionario>>().Setup(m => m.Provider).Returns(funcionarios.Provider);
            //mockSet.As<IQueryable<Funcionario>>().Setup(m => m.Expression).Returns(funcionarios.Expression);
            //mockSet.As<IQueryable<Funcionario>>().Setup(m => m.ElementType).Returns(funcionarios.ElementType);
            //mockSet.As<IQueryable<Funcionario>>().Setup(m => m.GetEnumerator()).Returns(funcionarios.GetEnumerator());

            var mockContext = new Mock<EmpresaContext>();
            mockContext.Setup(c => c.Funcionarios).Returns(mockSet.Object);

            // Act - fetch books
            var repository = new FuncionarioRepositorio(mockContext.Object);
            var actual = repository.Get();

            // Asset
            // Ensure that 2 books are returned and
            // the first one's title is "Hamlet"
            Assert.Equal(2, 2);
            Assert.Equal("Funcionario 1", actual.First().Nome);
        }

        [Fact]
        public void TesteDeCriacaoDeUsuario()
        {
            // Arrange - We're mocking our dbSet & dbContext
            // in-memory implementations of you context and sets
            var mockSet = new Mock<DbSet<Funcionario>>();

            var mockContext = new Mock<EmpresaContext>();
            mockContext.Setup(m => m.Funcionarios).Returns(mockSet.Object);

            // Act - Add the book
            var repository = new FuncionarioRepositorio(mockContext.Object);
            var funcionario = new Funcionario(33333333, "Funcionario 3");
            repository.Add(funcionario);

            // Assert
            // These two lines of code verifies that a book was added once and
            // we saved our changes once.
            mockSet.Verify(m => m.Add(It.IsAny<Funcionario>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
