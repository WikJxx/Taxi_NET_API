﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Taxi_NET_API.Data;

#nullable disable

namespace TaxiNETAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Taxi_NET_API.Models.CombustionTaxi", b =>
                {
                    b.Property<int>("CombustionTaxiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CombustionTaxiID"));

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarDoor")
                        .HasColumnType("int");

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGearBox")
                        .HasColumnType("bit");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int>("TravelRange")
                        .HasColumnType("int");

                    b.HasKey("CombustionTaxiID");

                    b.ToTable("CombustionTaxis");
                });

            modelBuilder.Entity("Taxi_NET_API.Models.ElectricTaxi", b =>
                {
                    b.Property<int>("electricTaxiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("electricTaxiID"));

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarDoor")
                        .HasColumnType("int");

                    b.Property<string>("Colour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGearBox")
                        .HasColumnType("bit");

                    b.Property<int>("ProductionYear")
                        .HasColumnType("int");

                    b.Property<int>("TravelRange")
                        .HasColumnType("int");

                    b.Property<int>("batteryCapacity")
                        .HasColumnType("int");

                    b.HasKey("electricTaxiID");

                    b.ToTable("ElectricTaxis");
                });

            modelBuilder.Entity("Taxi_NET_API.Models.TaxiDriver", b =>
                {
                    b.Property<int>("TaxiDriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxiDriverID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<bool>("IsManualLicence")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XCoordinates")
                        .HasColumnType("int");

                    b.Property<int>("YCoordinates")
                        .HasColumnType("int");

                    b.HasKey("TaxiDriverID");

                    b.ToTable("TaxiDrivers");
                });

            modelBuilder.Entity("Taxi_NET_API.Models.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<int>("XFinishCoordinates")
                        .HasColumnType("int");

                    b.Property<int>("XStartCoordinates")
                        .HasColumnType("int");

                    b.Property<int>("YFinishCoordinates")
                        .HasColumnType("int");

                    b.Property<int>("YStartCoordinates")
                        .HasColumnType("int");

                    b.HasKey("TripID");

                    b.ToTable("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
