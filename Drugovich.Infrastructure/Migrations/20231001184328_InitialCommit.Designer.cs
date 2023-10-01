﻿// <auto-generated />
using System;
using Drugovich.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Drugovich.Infrastructure.Migrations
{
    [DbContext(typeof(DrugovichDbContext))]
    [Migration("20231001184328_InitialCommit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Drugovich.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Registered");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Drugovich.Domain.Entities.CustomerGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("GroupName");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdate");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Registered");

                    b.HasKey("Id");

                    b.ToTable("CustomerGroups", (string)null);
                });

            modelBuilder.Entity("Drugovich.Domain.Entities.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Email");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("LastUpdate");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<DateTime>("Registered")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("Registered");

                    b.HasKey("Id");

                    b.ToTable("Managers", (string)null);
                });

            modelBuilder.Entity("Drugovich.Domain.Entities.Customer", b =>
                {
                    b.HasOne("Drugovich.Domain.Entities.CustomerGroup", "CustomerGroup")
                        .WithOne()
                        .HasForeignKey("Drugovich.Domain.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerGroup");
                });
#pragma warning restore 612, 618
        }
    }
}
