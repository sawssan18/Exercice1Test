using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{

    public class Airport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  Code { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [InverseProperty("ArrivalAirport")]
        public virtual ICollection<Flight> ArrivedFlights { get; set; }
        [InverseProperty("DepartureAirport")]
        public virtual ICollection<Flight> DepartingFlights { get; set; }
    }
}
