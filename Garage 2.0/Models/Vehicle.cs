using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegNr { get; set; }

        public Typ Typ { get; set; }
        public DateTime TimeOfParking { get; set; }
        public int NumnOfWheels { get; set; }

        public String Color { get; set; }
        public String Model { get; set; }
        public String Brand { get; set; }
    }

    public enum Typ
    {
        Car,
        Boat,
        Buss,
        Airplane
    }
}
