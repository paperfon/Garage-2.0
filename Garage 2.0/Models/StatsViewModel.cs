using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class StatsViewModel
    {
        public Typ VTyp { get; set; }

        public int Count { get; set; }

        public int SumOFwheels { get; set; }

        public double TotalMin { get; set; }
        public double TotalPrice { get; set; }

    }
}
