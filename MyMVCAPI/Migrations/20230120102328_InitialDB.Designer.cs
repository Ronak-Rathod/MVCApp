﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMVCAPI.Models;

#nullable disable

namespace MyMVCAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230120102328_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyMVCAPI.Models.Course", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"));

                    b.Property<string>("author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("price")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Lecture", b =>
                {
                    b.Property<int>("LId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LId"));

                    b.Property<int>("MId")
                        .HasColumnType("int");

                    b.Property<string>("heading")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("src")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LId");

                    b.HasIndex("MId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Module", b =>
                {
                    b.Property<int>("MId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MId"));

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MId");

                    b.HasIndex("CId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("MyMVCAPI.Models.StuCou", b =>
                {
                    b.Property<int>("SCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SCId"));

                    b.Property<int>("CId")
                        .HasColumnType("int");

                    b.Property<int>("SId")
                        .HasColumnType("int");

                    b.HasKey("SCId");

                    b.HasIndex("CId");

                    b.HasIndex("SId");

                    b.ToTable("StuCous");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Student", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SId"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Lecture", b =>
                {
                    b.HasOne("MyMVCAPI.Models.Module", "Module")
                        .WithMany("Lectures")
                        .HasForeignKey("MId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Module", b =>
                {
                    b.HasOne("MyMVCAPI.Models.Course", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("MyMVCAPI.Models.StuCou", b =>
                {
                    b.HasOne("MyMVCAPI.Models.Course", "Course")
                        .WithMany("StuCous")
                        .HasForeignKey("CId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyMVCAPI.Models.Student", "Student")
                        .WithMany("StuCous")
                        .HasForeignKey("SId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Course", b =>
                {
                    b.Navigation("Modules");

                    b.Navigation("StuCous");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Module", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("MyMVCAPI.Models.Student", b =>
                {
                    b.Navigation("StuCous");
                });
#pragma warning restore 612, 618
        }
    }
}
