using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage_2._0.Models
{
    public class MockVehicleRepository : IVehicleRepository
    {
        public IEnumerable<Vehicle> AllVehicles =>
            new List<Vehicle>
            {
                new Vehicle {Id=1, RegNr="ABC123", Typ=Typ.Car, TimeOfParking=DateTime.Now, NumnOfWheels=4, Color="Green", Model="Stationwagon", Brand="Volvo" },
                new Vehicle {Id=2, RegNr="BCD234", Typ=Typ.Buss, TimeOfParking=DateTime.Now, NumnOfWheels=8, Color="Red", Model="DoubleDecker", Brand="Scania" },
                new Vehicle {Id=3, RegNr="CDE345", Typ=Typ.Airplane, TimeOfParking=DateTime.Now, NumnOfWheels=6, Color="Silver", Model="DC10", Brand="Lockheed" },
                new Vehicle {Id=4, RegNr="DEF456", Typ=Typ.Boat, TimeOfParking=DateTime.Now, NumnOfWheels=0, Color="Brown", Model="Sailingboat", Brand="Penta" },
            };

        public Vehicle GetVehicleById(int Id)
        {
            return AllVehicles.FirstOrDefault(p => p.Id == Id);
        }

        public Vehicle GetVehiclebyRegNr(string RegNr)
        {
            return AllVehicles.FirstOrDefault(p => p.RegNr == RegNr);
        }
    }
}
