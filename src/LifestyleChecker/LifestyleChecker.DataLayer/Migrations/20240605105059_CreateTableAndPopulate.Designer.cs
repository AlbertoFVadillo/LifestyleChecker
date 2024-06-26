﻿// <auto-generated />
using System;
using LifestyleChecker.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LifestyleChecker.DataLayer.Migrations
{
    [DbContext(typeof(ScoreContext))]
    [Migration("20240605105059_CreateTableAndPopulate")]
    partial class CreateTableAndPopulate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LifestyleChecker.DataLayer.Models.Score", b =>
                {
                    b.Property<int>("Score_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Score_ID"), 1L, 1);

                    b.Property<int>("From")
                        .HasColumnType("int");

                    b.Property<int>("Q1")
                        .HasColumnType("int");

                    b.Property<int>("Q2")
                        .HasColumnType("int");

                    b.Property<int>("Q3")
                        .HasColumnType("int");

                    b.Property<int?>("To")
                        .HasColumnType("int");

                    b.HasKey("Score_ID");

                    b.ToTable("Scores");

                    b.HasData(
                        new
                        {
                            Score_ID = 1,
                            From = 16,
                            Q1 = 1,
                            Q2 = 2,
                            Q3 = 1,
                            To = 21
                        },
                        new
                        {
                            Score_ID = 2,
                            From = 22,
                            Q1 = 2,
                            Q2 = 2,
                            Q3 = 3,
                            To = 40
                        },
                        new
                        {
                            Score_ID = 3,
                            From = 41,
                            Q1 = 3,
                            Q2 = 2,
                            Q3 = 2,
                            To = 65
                        },
                        new
                        {
                            Score_ID = 4,
                            From = 64,
                            Q1 = 3,
                            Q2 = 3,
                            Q3 = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
