﻿// <auto-generated />
using System;
using AmazonFbaApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmazonFbaApi.Migrations
{
    [DbContext(typeof(AmazonApiContext))]
    [Migration("20250418142145_mig4")]
    partial class mig4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmazonFbaApi.Entities.UsaToAuMonthlySale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuantitySold")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleMonth")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsaToAuProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsaToAuProductId");

                    b.ToTable("UsaToAuMonthlySales");
                });

            modelBuilder.Entity("AmazonFbaApi.Entities.UsaToAuProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Asin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AuPrice")
                        .HasColumnType("float");

                    b.Property<double>("EarnAud")
                        .HasColumnType("float");

                    b.Property<double>("EarnUsd")
                        .HasColumnType("float");

                    b.Property<double>("FbaFee")
                        .HasColumnType("float");

                    b.Property<double>("FbaSalesFee")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<float>("Roi")
                        .HasColumnType("real");

                    b.Property<double>("ShipmentPrice")
                        .HasColumnType("float");

                    b.Property<double>("UsaPrice")
                        .HasColumnType("float");

                    b.Property<double>("WeightKg")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("UsaToAuProduct");
                });

            modelBuilder.Entity("AmazonFbaApi.Entities.UsaToAuMonthlySale", b =>
                {
                    b.HasOne("AmazonFbaApi.Entities.UsaToAuProduct", "Product")
                        .WithMany("MonthlySales")
                        .HasForeignKey("UsaToAuProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AmazonFbaApi.Entities.UsaToAuProduct", b =>
                {
                    b.Navigation("MonthlySales");
                });
#pragma warning restore 612, 618
        }
    }
}
