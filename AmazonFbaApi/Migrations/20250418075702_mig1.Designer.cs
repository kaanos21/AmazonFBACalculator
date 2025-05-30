﻿// <auto-generated />
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
    [Migration("20250418075702_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<double>("FbaFee")
                        .HasColumnType("float");

                    b.Property<double>("FbaSalesFee")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("ShipmentPrice")
                        .HasColumnType("float");

                    b.Property<double>("UsaPrice")
                        .HasColumnType("float");

                    b.Property<double>("WeightKg")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("UsaToAuProduct");
                });
#pragma warning restore 612, 618
        }
    }
}
