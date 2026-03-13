using Microsoft.AspNetCore.Mvc;
using CarRental.MVC.Models;

namespace CarRental.MVC.Controllers
{
    public class CustomerProfileController : Controller
    {
        private readonly HttpClient _httpClient;

        public CustomerProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CarRentalApi");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/v1/Customers");
            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerViewModel>>();
                return View(customers);
            }
            return View(new List<CustomerViewModel>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"api/v1/Customers/{id}");
            if (response.IsSuccessStatusCode)
            {
                var customer = await response.Content.ReadFromJsonAsync<CustomerViewModel>();
                return View(customer);
            }
            return NotFound();
        }
    }
}