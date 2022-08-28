﻿// <auto-generated />
using System;
using CuentaNTT.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CuentaNTT.Repository.Migrations
{
    [DbContext(typeof(CuentaNTTDBContext))]
    [Migration("20220827173627_CuentaNTT")]
    partial class CuentaNTT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CuentaNTT.Core.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("cli_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClienteID")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("cli_usuario");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("cli_contrasena");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("cli_estado");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int")
                        .HasColumnName("cli_personaId");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("cli_salt");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId")
                        .IsUnique();

                    b.ToTable("clienteNTT", (string)null);
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Cuenta", b =>
                {
                    b.Property<string>("NumeroCuenta")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("cue_numero_cuenta");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int")
                        .HasColumnName("cue_clienteId");

                    b.Property<bool>("Estado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("cue_estado");

                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("cue_id");

                    b.Property<decimal>("SaldoInicial")
                        .HasColumnType("decimal(15,3)")
                        .HasColumnName("cue_saldo_inicial");

                    b.Property<string>("TipoCuenta")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("cue_tipo_cuenta");

                    b.HasKey("NumeroCuenta");

                    b.HasIndex("ClienteId");

                    b.ToTable("cuentaNTT", (string)null);
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("mov_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CuentaId")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("mov_cuentaId");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime")
                        .HasColumnName("mov_usuario");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(15,3)")
                        .HasColumnName("mov_saldo");

                    b.Property<string>("TipoMovimiento")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("mov_tipo_movimiento");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15,3)")
                        .HasColumnName("mov_valor");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("movimientoNTT", (string)null);
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("per_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnName("per_clientId");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)")
                        .HasColumnName("per_direccion");

                    b.Property<int>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("per_edad");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("per_genero");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("per_identificacion");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)")
                        .HasColumnName("per_nombre");

                    b.Property<string>("Telefono")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("per_telefono");

                    b.HasKey("Id");

                    b.ToTable("personaNTT", (string)null);
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Cliente", b =>
                {
                    b.HasOne("CuentaNTT.Core.Models.Persona", "Persona")
                        .WithOne("Cliente")
                        .HasForeignKey("CuentaNTT.Core.Models.Cliente", "PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Cuenta", b =>
                {
                    b.HasOne("CuentaNTT.Core.Models.Cliente", "Cliente")
                        .WithMany("Cuentas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Movimiento", b =>
                {
                    b.HasOne("CuentaNTT.Core.Models.Cuenta", "Cuenta")
                        .WithMany("Movimientos")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Cliente", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Cuenta", b =>
                {
                    b.Navigation("Movimientos");
                });

            modelBuilder.Entity("CuentaNTT.Core.Models.Persona", b =>
                {
                    b.Navigation("Cliente")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
