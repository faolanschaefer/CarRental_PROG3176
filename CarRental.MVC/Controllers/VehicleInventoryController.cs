using Microsoft.AspNetCore.Mvc;
using CarRental.MVC.Models;

namespace CarRental.MVC.Controllers
{
    public class VehicleInventoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public VehicleInventoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CarRentalApi");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/v1/Vehicles");
            if (response.IsSuccessStatusCode)
            {
                var vehicles = await response.Content.ReadFromJsonAsync<IEnumerable<VehicleViewModel>>();
                return View(vehicles);
            }
            return View(new List<VehicleViewModel>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/Vehicles/{id}");
            if (response.IsSuccessStatusCode)
            {
                var vehicle = await response.Content.ReadFromJsonAsync<VehicleViewModel>();
                return View(vehicle);
            }
            return NotFound();
        }
    }
}