using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.Entities;

namespace Domain.Repository
{
    public class AirlineCompanyRepository : IAirlineCompanyRepository
    {
        private FlightContext _FlightContextDb;
        public AirlineCompanyRepository (FlightContext flightContext)
        {
            _FlightContextDb = flightContext;
        }
        public Airlinecompany GetAirlinecompanyById(int idAirline)
        {
         try
            {
                return _FlightContextDb.AirlinesCompanies.FirstOrDefault(c => c.Id.Equals(idAirline));

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<Airlinecompany> GetAllAirlines()
        {
            try
            {
                return _FlightContextDb.AirlinesCompanies.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
