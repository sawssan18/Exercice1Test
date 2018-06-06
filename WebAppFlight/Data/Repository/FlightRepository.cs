using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private FlightContext contextDb;
        public FlightRepository(FlightContext _context)
        {
            this.contextDb = _context;
        }
        public int AddFlight(Flight flight)
        {
            try
            {
                contextDb.Flights.Add (flight);
                contextDb.SaveChanges();
                return flight.FlightId;
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public bool DeleteFlightByID(int idFlight)
        {
            Flight flight = contextDb.Flights.FirstOrDefault(f => f.FlightId.Equals(idFlight));
            if (flight != null)
            {
                contextDb.Flights.Remove(flight);
                contextDb.SaveChanges();
                return true;
            }
            return false;
        }
        public bool EditFlight(Flight flight)
        {
            try
            {
                contextDb.Flights.Update(flight);
                return contextDb.SaveChanges() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<Flight> GetAllFlight()
        {
            try
            {
                return contextDb.Flights.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Flight GetFlightByID(int idFlight)
        {
            try
            {
                return contextDb.Flights.Include(f => f.FlightAirline)
                    .Include(f => f.ArrivalAirport).SingleOrDefault(f => f.FlightId == idFlight);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}