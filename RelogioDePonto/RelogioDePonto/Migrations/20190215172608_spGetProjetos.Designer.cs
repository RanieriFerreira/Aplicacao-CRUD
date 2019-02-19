﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelogioDePonto;

namespace CRUD_Empresa.Migrations
{
    [DbContext(typeof(ContextEmpresa))]
    [Migration("20190215172608_spGetProjetos")]
    partial class spGetProjetos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRUD_Empresa.Models.FuncionarioProjeto", b =>
                {
                    b.Property<int>("FuncionarioId");

                    b.Property<int>("ProjetoId");

                    b.HasKey("FuncionarioId", "ProjetoId");

                    b.ToTable("FuncionariosProjetos");
                });

            modelBuilder.Entity("RelogioDePonto.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("RelogioDePonto.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalhe");

                    b.Property<string>("Nome");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}