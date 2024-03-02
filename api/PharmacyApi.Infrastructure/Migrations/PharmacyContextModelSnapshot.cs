﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyApi.Infrastructure.Repositories.PharmacyRepository;

#nullable disable

namespace PharmacyApi.Infrastructure.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    partial class PharmacyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmacyApi.Domain.Entities.Pharmacy", b =>
                {
                    b.Property<long>("PharmacyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PharmacyId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfFilledPrescriptions")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("PharmacyId");

                    b.ToTable("Pharmacies");

                    b.HasData(
                        new
                        {
                            PharmacyId = 1L,
                            Address = "150 E Stacy Rd Suite 2400",
                            City = "Allen",
                            CreatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7430),
                            Name = "CVS Pharmacy",
                            NumberOfFilledPrescriptions = 0,
                            State = "TX",
                            UpdatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480),
                            Zip = "75002"
                        },
                        new
                        {
                            PharmacyId = 2L,
                            Address = "575 E Exchange Pkwy",
                            City = "Allen",
                            CreatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480),
                            Name = "H-E-B Pharmacy",
                            NumberOfFilledPrescriptions = 0,
                            State = "TX",
                            UpdatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480),
                            Zip = "75002"
                        },
                        new
                        {
                            PharmacyId = 3L,
                            Address = "730 W Exchange Pkwy",
                            City = "Allen",
                            CreatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480),
                            Name = "Walmart Pharmacy",
                            NumberOfFilledPrescriptions = 0,
                            State = "TX",
                            UpdatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480),
                            Zip = "75013"
                        },
                        new
                        {
                            PharmacyId = 4L,
                            Address = "500 E Stacy Rd",
                            City = "Allen",
                            CreatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480),
                            Name = "Walgreens Pharmacy",
                            NumberOfFilledPrescriptions = 0,
                            State = "TX",
                            UpdatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7490),
                            Zip = "75002"
                        },
                        new
                        {
                            PharmacyId = 5L,
                            Address = "1210 N Greenville Ave",
                            City = "Allen",
                            CreatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7490),
                            Name = "Kroger Pharmacy",
                            NumberOfFilledPrescriptions = 0,
                            State = "TX",
                            UpdatedDate = new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7490),
                            Zip = "75002"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}