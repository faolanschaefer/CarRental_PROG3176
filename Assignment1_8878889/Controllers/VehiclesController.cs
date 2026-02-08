using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Services;

namespace VehicleInventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleService _service;

        public VehiclesController(VehicleService service)
        {
            _service = service;
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] UpdateVehicleStatusDto request)
        {
            _service.UpdateVehicleStatus(id, request.Status);
            return NoContent();
        }
    }
}
