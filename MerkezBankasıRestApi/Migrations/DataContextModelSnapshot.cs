﻿// <auto-generated />
using MerkezBankasıRestApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MerkezBankasıRestApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MerkezBankasıRestApi.Kurlar.ResponseDataKur", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("AlisKuru")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Birimi")
                        .HasColumnType("int");

                    b.Property<decimal>("EfektifAlisKuru")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EfektifSatisKuru")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Kodu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SatisKuru")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Tarih")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Response");
                });
#pragma warning restore 612, 618
        }
    }
}
