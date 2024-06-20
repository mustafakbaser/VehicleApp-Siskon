using Microsoft.AspNetCore.Mvc;
using VehicleApp_SiskonAutomation.Models;
using VehicleApp_SiskonAutomation.Repositories;

namespace VehicleApp_SiskonAutomation.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly IVehicleRepository _repository;

        public VehiclesController(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var vehicles = await _repository.GetAllVehiclesAsync();
            return View(vehicles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddVehicleAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var vehicle = await _repository.GetVehicleByPlateAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateVehicleAsync(vehicle);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // Delete Vehicle Method
        public async Task<IActionResult> Delete(string id)
        {
            var vehicle = await _repository.GetVehicleByPlateAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            //await _repository.DeleteVehicleAsync(id);
            return View(vehicle);
            //return RedirectToAction(nameof(Index));
        }

        // Vehicle/DeleteConfirmed/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _repository.DeleteVehicleAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
