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

        public DbSet<Garage_2._0.Models.Vehicle> Vehicle { get; set; }
    }
}
