﻿// <auto-generated />
using System;
using CRC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRC.Data.Migrations
{
    [DbContext(typeof(CrcDbContext))]
    [Migration("20241119140058_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRC.Domain.Entities.Auth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_AUTH");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("HashSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HASH_SENHA");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("T_OP_CRC_AUTH");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Bonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_BONUS");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Custo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("CUSTO");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DESCRICAO");

                    b.Property<int>("IdCondominio")
                        .HasColumnType("int")
                        .HasColumnName("ID_CONDOMINIO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<int>("QtdMax")
                        .HasColumnType("int")
                        .HasColumnName("QTD_MAX");

                    b.HasKey("Id");

                    b.HasIndex("IdCondominio");

                    b.ToTable("T_OP_CRC_BONUS");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Condominio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_CONDOMINIO");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.ToTable("T_OP_CRC_CONDOMINIO");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Fatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_FATURA");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DtGeracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DT_GERACAO");

                    b.Property<int>("IdMorador")
                        .HasColumnType("int")
                        .HasColumnName("ID_MORADOR");

                    b.Property<int>("QtdConsumida")
                        .HasColumnType("int")
                        .HasColumnName("QTD_CONSUMIDA");

                    b.HasKey("Id");

                    b.HasIndex("IdMorador");

                    b.ToTable("T_OP_CRC_FATURA");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Morador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_MORADOR");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CPF");

                    b.Property<int>("IdAuth")
                        .HasColumnType("int")
                        .HasColumnName("ID_AUTH");

                    b.Property<int>("IdCondominio")
                        .HasColumnType("int")
                        .HasColumnName("ID_CONDOMINIO");

                    b.Property<string>("IdentificadorRes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("IDENTIFICADOR_RES");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NOME");

                    b.Property<int?>("Pontos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("PONTOS");

                    b.Property<int>("QtdMoradores")
                        .HasColumnType("int")
                        .HasColumnName("QTD_MORADORES");

                    b.HasKey("Id");

                    b.HasIndex("IdAuth")
                        .IsUnique();

                    b.HasIndex("IdCondominio");

                    b.HasIndex("Cpf", "IdAuth")
                        .IsUnique();

                    b.ToTable("T_OP_CRC_MORADOR");
                });

            modelBuilder.Entity("CRC.Domain.Entities.MoradorBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID_MB");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdBonus")
                        .HasColumnType("int")
                        .HasColumnName("ID_BONUS");

                    b.Property<int>("IdMorador")
                        .HasColumnType("int")
                        .HasColumnName("ID_MORADOR");

                    b.Property<int>("Qtd")
                        .HasColumnType("int")
                        .HasColumnName("QTD");

                    b.HasKey("Id");

                    b.HasIndex("IdBonus");

                    b.HasIndex("IdMorador");

                    b.ToTable("T_OP_CRC_MORADOR_BONUS");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Bonus", b =>
                {
                    b.HasOne("CRC.Domain.Entities.Condominio", "Condominio")
                        .WithMany("Bonus")
                        .HasForeignKey("IdCondominio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Fatura", b =>
                {
                    b.HasOne("CRC.Domain.Entities.Morador", "Morador")
                        .WithMany("Faturas")
                        .HasForeignKey("IdMorador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Morador");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Morador", b =>
                {
                    b.HasOne("CRC.Domain.Entities.Auth", "Auth")
                        .WithOne("Morador")
                        .HasForeignKey("CRC.Domain.Entities.Morador", "IdAuth")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CRC.Domain.Entities.Condominio", "Condominio")
                        .WithMany("Moradores")
                        .HasForeignKey("IdCondominio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auth");

                    b.Navigation("Condominio");
                });

            modelBuilder.Entity("CRC.Domain.Entities.MoradorBonus", b =>
                {
                    b.HasOne("CRC.Domain.Entities.Bonus", "Bonus")
                        .WithMany("MoradorBonus")
                        .HasForeignKey("IdBonus")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CRC.Domain.Entities.Morador", "Morador")
                        .WithMany("MoradorBonus")
                        .HasForeignKey("IdMorador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bonus");

                    b.Navigation("Morador");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Auth", b =>
                {
                    b.Navigation("Morador")
                        .IsRequired();
                });

            modelBuilder.Entity("CRC.Domain.Entities.Bonus", b =>
                {
                    b.Navigation("MoradorBonus");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Condominio", b =>
                {
                    b.Navigation("Bonus");

                    b.Navigation("Moradores");
                });

            modelBuilder.Entity("CRC.Domain.Entities.Morador", b =>
                {
                    b.Navigation("Faturas");

                    b.Navigation("MoradorBonus");
                });
#pragma warning restore 612, 618
        }
    }
}