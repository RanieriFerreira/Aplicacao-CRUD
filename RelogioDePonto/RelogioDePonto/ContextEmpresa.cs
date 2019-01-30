﻿using RelogioDePonto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=EmpresaDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<Projeto>().HasIndex(u => u.Id).IsUnique();
        }

        // Entidades
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Projeto> Projetos { get; set; }
    }
}
