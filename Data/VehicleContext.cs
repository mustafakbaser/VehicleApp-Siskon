using Microsoft.EntityFrameworkCore;
using VehicleApp_SiskonAutomation.Models;

namespace VehicleApp_SiskonAutomation.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
