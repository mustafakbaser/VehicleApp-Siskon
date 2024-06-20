using VehicleApp_SiskonAutomation.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleApp_SiskonAutomation.Repositories
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle> GetVehicleByPlateAsync(string plate);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(string plate);
    }
}
