using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Services;
using VehicleInventory.Domain.Entities;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            var vehicles = _service.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var vehicle = _service.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Inventory request) // TODO: Change to CreateVehicleDto
        {
            var createdVehicle = _service.CreateVehicle(request);
            return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string request) // TODO: Change to UpdateVehicleStatusDto
        {
            _service.UpdateVehicleStatus(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteVehicle(id);
            return NoContent();
        }
    }
}
