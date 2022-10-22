﻿// <auto-generated />
using System;
using Infra.DataContext.EF.Ports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.DataContext.EF.Migrations
{
    [DbContext(typeof(PortsDbDataContext))]
    partial class PortsDbDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Ports.Ancre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("Poids")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Ancres");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Bateau", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AncreId")
                        .HasColumnType("int");

                    b.Property<int>("CapitaineId")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PortId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AncreId")
                        .IsUnique();

                    b.HasIndex("CapitaineId");

                    b.HasIndex("PortId");

                    b.ToTable("Bateaux");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Capitaine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Capitaines");
                });

            modelBuilder.Entity("Domain.Entities.Ports.CapitaineDiplome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AnneeObtention")
                        .HasColumnType("bigint");

                    b.Property<int>("CapitaineId")
                        .HasColumnType("int");

                    b.Property<int>("DiplomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiplomeId");

                    b.HasIndex("CapitaineId", "DiplomeId")
                        .IsUnique();

                    b.ToTable("CapitainesDiplomes");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Diplome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Intitule")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Intitule")
                        .IsUnique();

                    b.ToTable("Diplomes");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Port", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VilleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VilleId");

                    b.ToTable("Ports");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Nom")
                        .IsUnique();

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Bateau", b =>
                {
                    b.HasOne("Domain.Entities.Ports.Ancre", "Ancre")
                        .WithMany()
                        .HasForeignKey("AncreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Ports.Capitaine", "Capitaine")
                        .WithMany()
                        .HasForeignKey("CapitaineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Ports.Port", null)
                        .WithMany("Bateaux")
                        .HasForeignKey("PortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ancre");

                    b.Navigation("Capitaine");
                });

            modelBuilder.Entity("Domain.Entities.Ports.CapitaineDiplome", b =>
                {
                    b.HasOne("Domain.Entities.Ports.Capitaine", "Capitaine")
                        .WithMany()
                        .HasForeignKey("CapitaineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Ports.Diplome", "Diplome")
                        .WithMany()
                        .HasForeignKey("DiplomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Capitaine");

                    b.Navigation("Diplome");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Port", b =>
                {
                    b.HasOne("Domain.Entities.Ports.Ville", null)
                        .WithMany("Ports")
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Ports.Port", b =>
                {
                    b.Navigation("Bateaux");
                });

            modelBuilder.Entity("Domain.Entities.Ports.Ville", b =>
                {
                    b.Navigation("Ports");
                });
#pragma warning restore 612, 618
        }
    }
}