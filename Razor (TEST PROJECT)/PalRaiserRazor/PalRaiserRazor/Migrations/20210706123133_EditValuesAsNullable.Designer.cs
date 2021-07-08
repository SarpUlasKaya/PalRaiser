﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PalRaiserRazor.Model;

namespace PalRaiserRazor.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210706123133_EditValuesAsNullable")]
    partial class EditValuesAsNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PalRaiserRazor.Model.Project", b =>
                {
                    b.Property<int>("ProjId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AmountRaised")
                        .HasColumnType("int");

                    b.Property<string>("DetailedInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DislikeCount")
                        .HasColumnType("int");

                    b.Property<int?>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("ProjName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReportCount")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TestValue")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjId");

                    b.ToTable("Project");
                });
#pragma warning restore 612, 618
        }
    }
}