using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Entities;

namespace Domain.Repository
{
  
    public class AircraftRepository : IAircraftRepository
    {
        private FlightContext _FlightContextDb;
        public AircraftRepository(FlightContext flightContext)
        {
            _FlightContextDb = flightContext;
        }
        public Aircraft GetAircraftById(int idAircraft)
        {
            try
            {
                return _FlightContextDb.Aircrafts.FirstOrDefault(a => a.Id.Equals(idAircraft));
           
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Aircraft> GetAllAircraft()
        {
            try
            {
                return _FlightContextDb.Aircrafts.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
