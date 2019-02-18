using RelogioDePonto.Models;
using Microsoft.EntityFrameworkCore;
using CRUD_Empresa.Models;
using CRUD_Empresa.ViewsModels;

namespace RelogioDePonto
{
    public class ContextEmpresa : DbContext 
    {
        public ContextEmpresa()
        {
        }

        public ContextEmpresa(DbContextOptions<ContextEmpresa> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<Projeto>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<FuncionarioProjeto>().HasKey(sc => new { sc.FuncionarioId, sc.ProjetoId });

            modelBuilder.Entity<FuncionarioProjeto>()
                .HasOne(pt => pt.Funcionario)
                .WithMany(p => p.ProjetosLink)
                .HasForeignKey(pt => pt.FuncionarioId);

            modelBuilder.Entity<FuncionarioProjeto>()
                .HasOne(pt => pt.Projeto)
                .WithMany(t => t.FuncionariosLink)
                .HasForeignKey(pt => pt.ProjetoId);
        }

        // Entidades
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
        public virtual DbSet<FuncionarioProjeto> FuncionariosProjetos { get; set; }
    }
}
