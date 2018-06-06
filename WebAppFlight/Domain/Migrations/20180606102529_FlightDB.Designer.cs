﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(FlightContext))]
    [Migration("20180606102529_FlightDB")]
    partial class FlightDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Entities.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AircraftType");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.HasKey("Id");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("Data.Entities.Airlinecompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AirlinesCompanies");
                });

            modelBuilder.Entity("Data.Entities.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("CountryName");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Data.Entities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AircraftId");

                    b.Property<int>("AirlineId");

                    b.Property<int>("ArrivalId");

                    b.Property<string>("Code");

                    b.Property<int>("DepartureId");

                    b.Property<DateTime>("FlightArrival");

                    b.Property<DateTime>("FlightDeparture");

                    b.Property<double>("FlightTime");

                    b.HasKey("FlightId");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("ArrivalId");

                    b.HasIndex("DepartureId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Data.Entities.Flight", b =>
                {
                    b.HasOne("Data.Entities.Aircraft", "Aircraft")
                        .WithMany("Flights")
                        .HasForeignKey("AircraftId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.Airlinecompany", "FlightAirline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.Airport", "ArrivalAirport")
                        .WithMany("ArrivedFlights")
                        .HasForeignKey("ArrivalId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Entities.Airport", "DepartureAirport")
                        .WithMany("DepartingFlights")
                        .HasForeignKey("DepartureId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
