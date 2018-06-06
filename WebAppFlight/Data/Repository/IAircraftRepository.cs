using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IAircraftRepository
    {
        List<Aircraft> GetAllAircraft();
        Aircraft GetAircraftById(int idAircraft);
    }
}
