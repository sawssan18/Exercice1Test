using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Entities;

namespace Domain.Repository
{
    public class AirportRepository : IAirportRepository
    {
        private FlightContext _ContextDb;
        public AirportRepository(FlightContext  contextDb)
        {
            _ContextDb = contextDb;
        }
        public Airport GetAirportById(int idAirport)
        {
            try
            {
                return _ContextDb.Airports.FirstOrDefault(a => a.Id.Equals(idAirport));
              
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Airport> GetAllAirport()
        {
            try
            {
                return _ContextDb.Airports.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
