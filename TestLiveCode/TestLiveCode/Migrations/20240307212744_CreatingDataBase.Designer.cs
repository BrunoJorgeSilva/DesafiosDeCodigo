﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestLiveCode.Context;

#nullable disable

namespace TestLiveCode.Migrations
{
    [DbContext(typeof(DbContextExample))]
    [Migration("20240307212744_CreatingDataBase")]
    partial class CreatingDataBase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestLiveCode.Model.Example", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR(250)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("Is_Deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR(500)");

                    b.HasKey("Id");

                    b.ToTable("Example");
                });

            modelBuilder.Entity("TestLiveCode.Model.ExampleDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR(1000)")
                        .HasColumnName("DETAILS");

                    b.Property<Guid>("ExampleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Example_Id");

                    b.HasKey("Id");

                    b.HasIndex("ExampleId");

                    b.ToTable("ExampleDetails");
                });

            modelBuilder.Entity("TestLiveCode.Model.ExampleDetails", b =>
                {
                    b.HasOne("TestLiveCode.Model.Example", "Example")
                        .WithMany("ExampleDetails")
                        .HasForeignKey("ExampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Example");
                });

            modelBuilder.Entity("TestLiveCode.Model.Example", b =>
                {
                    b.Navigation("ExampleDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
