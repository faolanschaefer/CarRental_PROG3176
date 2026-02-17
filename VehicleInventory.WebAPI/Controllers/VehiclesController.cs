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
            try
            {
                IEnumerable<VehicleDto> vehicles = _service.GetAllVehicles();
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                VehicleDto vehicle = _service.GetVehicleById(id);
                return Ok(vehicle);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVehicleDto request)
        {
            try
            {
                VehicleDto createdVehicle = _service.CreateVehicle(request);
                return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] UpdateVehicleStatusDto request)
        {
            try
            {
                _service.UpdateVehicleStatus(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}/release")]
        public IActionResult ReleaseReservation(int id)
        {
            try
            {
                _service.ReleaseVehicleReservation(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteVehicle(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
