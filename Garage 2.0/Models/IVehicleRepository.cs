using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> AllVehicles { get; }
        Vehicle GetVehicleById(int Id);
        Vehicle GetVehiclebyRegNr(string RegNr);

    }
}
