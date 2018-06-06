using Domain;
using GeoCoordinatePortable;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppFlight.Models;

namespace WebAppFlight.Helpers
{
    public class CalculateConsumption
    {
        public static List<FlightViewModel> CalculateData(List<FlightViewModel> model)
        {
            return model.Select(m =>
            {
                m.FlightDistance = CalculateConsumptionFuel
                .CalculateDistance(new GeoCoordinate
                (m.DepartureAirport.Latitude, m.DepartureAirport.Longitude),
                    new GeoCoordinate
                    (m.ArrivalAirport.Latitude, m.ArrivalAirport.Longitude));
                m.FlightTime = ((TimeSpan)(m.FlightArrival - m.FlightDeparture)).TotalHours;
                m.FuelConsumption = CalculateConsumptionFuel.CalculateFuelConsumption(m.FlightDistance, m.FlightTime);
                return m;
            }).ToList();


        }
    }
    }
