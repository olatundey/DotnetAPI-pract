﻿// <auto-generated />
using System;
using MagicVilla_VillaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230713033433_AddVilla2TableToddSeedDatdSeedData")]
    partial class AddVilla2TableToddSeedDatdSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MagicVilla_VillaAPI.Model.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("double");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                            Name = "Pool View",
                            Occupancy = 4,
                            Rate = 200.0,
                            Sqft = 100,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                            Name = "Lake View",
                            Occupancy = 5,
                            Rate = 600.0,
                            Sqft = 140,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                            Name = "Lake View",
                            Occupancy = 5,
                            Rate = 600.0,
                            Sqft = 140,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                            Name = "Lake View",
                            Occupancy = 5,
                            Rate = 600.0,
                            Sqft = 140,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Details = "Fusce 11 tincidunt maximus leo, sed scelerisque",
                            ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villas3.jpg",
                            Name = "Lake View",
                            Occupancy = 5,
                            Rate = 600.0,
                            Sqft = 140,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}