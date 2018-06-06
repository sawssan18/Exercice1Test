using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public interface IAirlineCompanyRepository 
    {
        List<Airlinecompany> GetAllAirlines();
        Airlinecompany GetAirlinecompanyById(int idAirline);

    }
}
