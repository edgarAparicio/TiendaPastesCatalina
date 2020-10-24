﻿// <auto-generated />
using System;
using EdgarAparicio.PastesCatalina.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EdgarAparicio.PastesCatalina.Data.Migrations
{
    [DbContext(typeof(DbContextPastesCatalina))]
    [Migration("20201023165934_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EdgarAparicio.PastesCatalina.Business.Entity.Paste", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<int?>("TipoSaborId");

                    b.HasKey("Id");

                    b.HasIndex("TipoSaborId");

                    b.ToTable("Paste");
                });

            modelBuilder.Entity("EdgarAparicio.PastesCatalina.Business.Entity.TipoSabor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("TipoSabor");
                });

            modelBuilder.Entity("EdgarAparicio.PastesCatalina.Business.Entity.Paste", b =>
                {
                    b.HasOne("EdgarAparicio.PastesCatalina.Business.Entity.TipoSabor", "TipoSabor")
                        .WithMany()
                        .HasForeignKey("TipoSaborId");
                });
#pragma warning restore 612, 618
        }
    }
}
