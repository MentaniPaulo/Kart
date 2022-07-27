﻿// <auto-generated />
using System;
using CorridaDeKart.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CorridaDeKart.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CorridaDeKart.Models.LogsOfRace", b =>
                {
                    b.Property<int>("LogsOfRaceKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PilotCode")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("PilotName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(10,3)");

                    b.Property<DateTime>("TimeOfTurn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Turn")
                        .HasColumnType("int");

                    b.HasKey("LogsOfRaceKey");

                    b.ToTable("logsOfRaces");
                });
#pragma warning restore 612, 618
        }
    }
}
