using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
   public  interface IFlightRepository
    {
        int AddFlight(Flight flight);
        bool DeleteFlightByID(int idFlight);
        Flight GetFlightByID(int idFlight);
        List<Flight> GetAllFlight();
        bool EditFlight(Flight fligh);
    }
}
