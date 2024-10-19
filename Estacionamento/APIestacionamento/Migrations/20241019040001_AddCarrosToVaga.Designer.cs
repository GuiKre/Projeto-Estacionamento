﻿// <auto-generated />
using System;
using APIestacionamento.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIestacionamento.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20241019040001_AddCarrosToVaga")]
    partial class AddCarrosToVaga
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("APIestacionamento.Models.Carro", b =>
                {
                    b.Property<int>("CarroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cor")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataChegada")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .HasColumnType("TEXT");

                    b.Property<int>("VagaId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VagaId1")
                        .HasColumnType("INTEGER");

                    b.HasKey("CarroId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VagaId");

                    b.HasIndex("VagaId1")
                        .IsUnique();

                    b.ToTable("Carros");
                });

            modelBuilder.Entity("APIestacionamento.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APIestacionamento.Models.Vaga", b =>
                {
                    b.Property<int>("VagaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.HasKey("VagaId");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("APIestacionamento.Models.Carro", b =>
                {
                    b.HasOne("APIestacionamento.Models.Cliente", "Cliente")
                        .WithMany("Carros")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIestacionamento.Models.Vaga", "vaga")
                        .WithMany("Carros")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIestacionamento.Models.Vaga", null)
                        .WithOne("carro")
                        .HasForeignKey("APIestacionamento.Models.Carro", "VagaId1");

                    b.Navigation("Cliente");

                    b.Navigation("vaga");
                });

            modelBuilder.Entity("APIestacionamento.Models.Cliente", b =>
                {
                    b.Navigation("Carros");
                });

            modelBuilder.Entity("APIestacionamento.Models.Vaga", b =>
                {
                    b.Navigation("Carros");

                    b.Navigation("carro");
                });
#pragma warning restore 612, 618
        }
    }
}
