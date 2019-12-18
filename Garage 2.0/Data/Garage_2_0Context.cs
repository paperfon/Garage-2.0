using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Garage_2._0.Models
{
    public class Garage_2_0Context : DbContext
    {
        public Garage_2_0Context (DbContextOptions<Garage_2_0Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasData(
                new Vehicle { Id = 1, RegNr = "ABC123", Typ = Typ.Car, TimeOfParking = DateTime.Now, NumnOfWheels = 4, Color = "Green", Model = "Stationwagon", Brand = "Volvo" },
                new Vehicle { Id = 2, RegNr = "BCD234", Typ = Typ.Buss, TimeOfParking = DateTime.Now, NumnOfWheels = 8, Color = "Red", Model = "DoubleDecker", Brand = "Scania" },
                new Vehicle { Id = 3, RegNr = "CDE345", Typ = Typ.Airplane, TimeOfParking = DateTime.Now, NumnOfWheels = 6, Color = "Silver", Model = "DC10", Brand = "Lockheed" },
                new Vehicle { Id = 4, RegNr = "DEF456", Typ = Typ.Motorcykel, TimeOfParking = DateTime.Now, NumnOfWheels = 0, Color = "Brown", Model = "Sailingboat", Brand = "Penta" },
                new Vehicle { Id = 5, RegNr = "ASD345", Typ = Typ.Car, TimeOfParking = DateTime.Parse("1997-02-22"), NumnOfWheels = 34, Color = "Violet", Model = "BladeRunner", Brand = "BMW"}
                );
        }

        public DbSet<Garage_2._0.Models.Vehicle> Vehicle { get; set; }
    }
}
