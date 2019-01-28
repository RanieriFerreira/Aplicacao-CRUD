using RelogioDePonto.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RelogioDePonto
{
    public class EmpresaContext : DbContext 
    {
        public EmpresaContext()
        {
        }

        public EmpresaContext(DbContextOptions<EmpresaContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EmpresaDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        // Entidades
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
    }
}
