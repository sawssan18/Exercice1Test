using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFlight.Models
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        public string Code { get; set; }
        public double FlightTime { get; set; }
        [Display(Name = "Departure")]
        [Required]
        public DateTime FlightDeparture { get; set; }
        [Display(Name = " Arrival")]
        [Required]
        public DateTime FlightArrival { get; set; }
        [Display(Name = " Departure Airport")]
        public string DepartureAirportName{ get; set; }
        public int DepartureId { get; set; }
        [Display(Name = " Arrival Airport")]
        public string ArrivalAirportName { get; set; }
        public int ArrivalId { get; set; }
        [Display(Name = " Aricraft")]
        public string AircraftName{ get; set; }
        public int AircraftId { get; set; }
        [Display(Name = " Airline")]
        public string AirlineName { get; set; }
        public int AirlineId { get; set; }

        public Airlinecompany Airline { get; set; }
        public Airport DepartureAirport { get; set; }
        public Airport ArrivalAirport { get; set; }
        public Aircraft Aircraft { get; set; }

        [Display(Name = "Distance")]
        public double FlightDistance { get; set; }
        [Display(Name = "Fuel Consumption")]
        public double FuelConsumption { get; set; }
        

    }
}
