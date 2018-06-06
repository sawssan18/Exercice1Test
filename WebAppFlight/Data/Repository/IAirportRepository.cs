using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
   public  interface IAirportRepository
    {
        List<Airport> GetAllAirport();
        Airport GetAirportById(int IdAirport);
    }
}
