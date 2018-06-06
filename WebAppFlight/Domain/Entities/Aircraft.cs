using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
   
    public class Aircraft
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string  Number { get; set; }
        public string  Name { get; set; }
        public string AircraftType { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
