﻿// <auto-generated />
using System;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevIO.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    partial class MeuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppMvcBasica.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("FornecedorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorID")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("AppMvcBasica.Models.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("TipoFornecedor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("AppMvcBasica.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("FornecedorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorID");

                    b.ToTable("PRODUTOS");
                });

            modelBuilder.Entity("AppMvcBasica.Models.Endereco", b =>
                {
                    b.HasOne("AppMvcBasica.Models.Fornecedor", "Fornecedor")
                        .WithOne("Endereco")
                        .HasForeignKey("AppMvcBasica.Models.Endereco", "FornecedorID")
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("AppMvcBasica.Models.Produto", b =>
                {
                    b.HasOne("AppMvcBasica.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorID")
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("AppMvcBasica.Models.Fornecedor", b =>
                {
                    b.Navigation("Endereco");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}