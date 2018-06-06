using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
  
    public class Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlightId { get; set; }
        public string Code { get; set; }
        public double FlightTime { get; set; }
        public DateTime FlightDeparture { get; set; }
        public DateTime FlightArrival { get; set; }
        public int DepartureId { get; set; }
        public int ArrivalId { get; set; }
        public int AircraftId { get; set; }
        public int AirlineId { get; set; }
        
        [ForeignKey("DepartureId")]
        public Airport DepartureAirport { get; set; }
        [ForeignKey("ArrivalId")]
        public Airport ArrivalAirport { get; set; }

        public Airlinecompany FlightAirline { get; set; }
        public Aircraft Aircraft { get; set; }

    }
}
