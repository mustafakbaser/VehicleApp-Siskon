using Microsoft.EntityFrameworkCore;
using VehicleApp_SiskonAutomation.Data;
using VehicleApp_SiskonAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleApp_SiskonAutomation.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleContext _context;
        public VehicleRepository(VehicleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicleByPlateAsync(string plate)
        {
            return await _context.Vehicles.FindAsync(plate);
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(string plate)
        {
            var vehicle = await _context.Vehicles.FindAsync(plate);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
