﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ConfigMan.Data;
using ConfigMan.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConfigMan.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230418205229_RemoveGUID")]
    partial class RemoveGUID
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConfigMan.Data.Models.Application", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<List<Setting>>("ApplicationDefaults")
                        .HasColumnType("jsonb");

                    b.Property<Dictionary<string, List<Setting>>>("EnvironmentSettings")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ConfigMan.Data.Models.DeploymentEnvironment", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<List<Setting>>("Settings")
                        .HasColumnType("jsonb");

                    b.HasKey("Name");

                    b.ToTable("Environments");
                });

            modelBuilder.Entity("ConfigMan.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
