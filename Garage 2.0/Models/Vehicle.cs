using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "RegNr is required!")]
        public string RegNr { get; set; }

        public Typ Typ { get; set; }
        public DateTime TimeOfParking { get; set; }
        [Range(0, 99, ErrorMessage = "No more than 99 wheels")]
        public int NumnOfWheels { get; set; }

        public string Color { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }

        public Vehicle()
        {
            TimeOfParking = DateTime.UtcNow;
        }
    }

    public enum Typ
    {
        Car,
        Boat,
        Buss,
        Airplane
    }
}
