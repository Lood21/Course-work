using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EvacUa.Models
{
    public class VehicleDb:DbContext
    {
        public VehicleDb(DbContextOptions<VehicleDb> options)
        : base(options) { }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        
    }
}
