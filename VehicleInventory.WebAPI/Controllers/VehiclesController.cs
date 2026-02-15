using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Services;

namespace VehicleInventory.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
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
            IEnumerable<VehicleDto> vehicles = _service.GetAllVehicles(); // TODO: Catch exceptions?
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VehicleDto vehicle = _service.GetVehicleById(id); // TODO: Catch exception
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVehicleDto request) 
        {
            VehicleDto createdVehicle = _service.CreateVehicle(request); // TODO: Catch exception?
            return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] UpdateVehicleStatusDto request) 
        {
            _service.UpdateVehicleStatus(id, request); // TODO: Catch exception
            return NoContent();
        }

        [HttpPut("{id}/release")]
        public IActionResult ReleaseReservation(int id)
        {
            try
            {
                _service.ReleaseVehicleReservation(id); 
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteVehicle(id); // TODO: Catch exception
            return NoContent();
        }
    }
}
