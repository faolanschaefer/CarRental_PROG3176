using Maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaintenanceController : Controller
    {
        private readonly IRepairHistoryService service;

        public MaintenanceController(IRepairHistoryService repairHistoryService)
        {
            service = repairHistoryService;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetRepairHistory(int vehicleId)
        {
            var history = service.GetByVehicleId(vehicleId);
            return Ok(history);
        }
    }
}
