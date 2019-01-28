﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RelogioDePonto;

namespace RelogioDePonto.Migrations
{
    [DbContext(typeof(EmpresaContext))]
    [Migration("20190128155622_sp-GetProjetos")]
    partial class spGetProjetos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RelogioDePonto.Modelos.Funcionario", b =>
                {
                    b.Property<double>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<int>("Status");

                    b.HasKey("Cpf");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("RelogioDePonto.Modelos.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Detalhe");

                    b.Property<string>("Nome");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
