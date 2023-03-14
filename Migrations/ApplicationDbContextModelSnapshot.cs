﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webapplication.Data;

#nullable disable

namespace Webapplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Webapplication.Models.Employees", b =>
                {
                    b.Property<int>("ReimbursementNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReimbursementNo"));

                    b.Property<string>("Attachment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Cost2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Cost3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Projecttitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SubmittedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Suggesstion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tripto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enddate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startdate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReimbursementNo");

                    b.ToTable("ReimbursementDetails");
                });

            modelBuilder.Entity("Webapplication.Models.Reviews", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ratings")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("RatingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}