using Maintenance.WebAPI.DTOs;
using Maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MaintenanceController : Controller
    {
        private readonly IRepairHistoryService _repairService;
        private readonly Dictionary<string, int> _usageCounts;

        public MaintenanceController(IRepairHistoryService repairHistoryService, Dictionary<string, int> usageCounts)
        {
            _repairService = repairHistoryService;
            _usageCounts = usageCounts;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetRepairHistory(int vehicleId)
        {
            var history = _repairService.GetByVehicleId(vehicleId);
            return Ok(history);
        }

        [HttpPost]
        public IActionResult AddRepair([FromBody] RepairHistoryDto repair)
        {
            if (repair.VehicleId <= 0)
            {
                return BadRequest(new
                {
                    error = "InvalidParameter",
                    message = "VehicleId must be greater than zero."
                });
            }
            if (string.IsNullOrWhiteSpace(repair.Description))
            {
                return BadRequest(new
                {
                    error = "InvalidParameter",
                    message = "Description must not be empty."
                });
            }
            if (repair.Cost < 0)
            {
                return BadRequest(new
                {
                    error = "InvalidParameter",
                    message = "Cost cannot be negative."
                });
            }
            var created = _repairService.AddRepair(repair);
            return CreatedAtAction(
            nameof(GetRepairHistory),
            new { vehicleId = created.VehicleId },
            created
            );
        }
        
        [HttpGet("crash")]
        public IActionResult Crash()
        {
            int x = 0;
            int y = 5 / x;
            return Ok();
        }

        [HttpGet("usage")]
        public IActionResult Usage()
        {
            var key = Request.Headers["X-Api-Key"].ToString();
            if (!_usageCounts.ContainsKey(key))
                _usageCounts[key] = 0;
            _usageCounts[key]++;
            return Ok(new
            {
                clientId = key,
                callCount = _usageCounts[key]
            });
        }
    }
}
