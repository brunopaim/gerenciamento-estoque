﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gerenciamento_estoque.Data;

#nullable disable

namespace gerenciamento_estoque.Migrations
{
    [DbContext(typeof(ProdutoContext))]
    partial class ProdutoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("gerenciamento_estoque.Models.EntradaMercadoria", b =>
                {
                    b.Property<int>("EntradaMercadoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroEntrada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PesoTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("TotalVolumeCubico")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("EntradaMercadoriaId");

                    b.ToTable("EntradaMercadorias");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.MapaEstoque", b =>
                {
                    b.Property<int>("MapaEstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CapacidadeMaxima")
                        .HasColumnType("int");

                    b.Property<int>("Coluna")
                        .HasColumnType("int");

                    b.Property<int>("Linha")
                        .HasColumnType("int");

                    b.HasKey("MapaEstoqueId");

                    b.ToTable("MapaEstoque");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("VolumeCubico")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.ProdutoEntrada", b =>
                {
                    b.Property<int>("ProdutoEntradaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EntradaMercadoriaId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroEntrada")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorUnitario")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("VolumeCubico")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ProdutoEntradaId");

                    b.HasIndex("EntradaMercadoriaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosEntradas");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.ProdutoEstoque", b =>
                {
                    b.Property<int>("ProdutoEstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MapaEstoqueId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoEntradaId")
                        .HasColumnType("int");

                    b.Property<float>("VolumeArmazenado")
                        .HasColumnType("float");

                    b.HasKey("ProdutoEstoqueId");

                    b.HasIndex("MapaEstoqueId");

                    b.HasIndex("ProdutoEntradaId");

                    b.ToTable("ProdutosEstoque");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.ProdutoEntrada", b =>
                {
                    b.HasOne("gerenciamento_estoque.Models.EntradaMercadoria", null)
                        .WithMany("ProdutosEntrada")
                        .HasForeignKey("EntradaMercadoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerenciamento_estoque.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.ProdutoEstoque", b =>
                {
                    b.HasOne("gerenciamento_estoque.Models.MapaEstoque", null)
                        .WithMany("ProdutoEstoque")
                        .HasForeignKey("MapaEstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("gerenciamento_estoque.Models.ProdutoEntrada", "ProdutoEntrada")
                        .WithMany("ProdutoEstoque")
                        .HasForeignKey("ProdutoEntradaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoEntrada");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.EntradaMercadoria", b =>
                {
                    b.Navigation("ProdutosEntrada");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.MapaEstoque", b =>
                {
                    b.Navigation("ProdutoEstoque");
                });

            modelBuilder.Entity("gerenciamento_estoque.Models.ProdutoEntrada", b =>
                {
                    b.Navigation("ProdutoEstoque");
                });
#pragma warning restore 612, 618
        }
    }
}
