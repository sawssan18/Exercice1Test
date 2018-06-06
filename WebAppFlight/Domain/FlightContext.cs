using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Airport>()
                .HasMany<Flight>(a => a.ArrivedFlights)
                .WithOne(f => f.ArrivalAirport)
                .HasForeignKey(a => a.ArrivalId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Airport>()
                .HasMany<Flight>(a => a.DepartingFlights)
                .WithOne(f => f.DepartureAirport)
                .HasForeignKey(a => a.DepartureId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Airlinecompany>()
              .HasMany<Flight>(a => a.Flights)
              .WithOne(f => f.FlightAirline)
              .HasForeignKey(a => a.AirlineId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Aircraft>()
             .HasMany<Flight>(a => a.Flights)
             .WithOne(f => f.Aircraft)
             .HasForeignKey(a => a.AircraftId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Airlinecompany> AirlinesCompanies { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
    }
}
