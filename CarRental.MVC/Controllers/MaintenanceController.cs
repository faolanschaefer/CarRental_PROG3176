using CarRental.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.MVC.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly HttpClient _httpClient;

        public MaintenanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CarRentalApi");
        }

        [HttpGet]
        public IActionResult History()
        {
            return View(new List<RepairHistoryViewModel>());
        }

        [HttpPost]

        public async Task<IActionResult> History(int vehicleId)
        {
            var repairs = await _httpClient.GetFromJsonAsync<List<RepairHistoryViewModel>>(
                $"api/v1/maintenance/vehicles/{vehicleId}/repairs");
            return View(repairs ?? new List<RepairHistoryViewModel>());
        }

        public async Task<IActionResult> Usage()
        {
            var result = await _httpClient.GetFromJsonAsync<object>("api/v1/maintenance/usage");
            return View(result);
        }

        // Huh?
        //public async Task<IActionResult> Transfer(int fromId, int toId, decimal amount)
        //{
        //    var response = await _httpClient.PostAsync(
        //    $"api/v1/maintenance/transfer?fromId={fromId}&toId={toId}&amount={amount}",
        //    null);
        //    var content = await response.Content.ReadAsStringAsync();
        //    ViewBag.Result = content;
        //    return View();
        //}
    }
}
