using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class ReceiptViewModel
    {
        public string RegNr { get; set; }
        public DateTime TimeOfParking { get; set; }
        public DateTime TimeOfUnParking { get; set; }
        public double TotalTimeOfParking { get; set; }
        public double Price { get; set; }
    }
}
