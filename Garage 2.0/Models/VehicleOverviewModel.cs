using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class VehicleOverviewModel
    {
        public Typ? Typ { get; set; }
        public string RegNr { get; set; }
        public string Color { get; set; }
        public DateTime TimeOfParking { get; set; }
    }
}
