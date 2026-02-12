using Microsoft.AspNetCore.Mvc;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Services;
using VehicleInventory.Domain.Aggregates;
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
            IEnumerable<VehicleAggregate> vehicles = _service.GetAllVehicles(); // TODO: Catch exceptions?
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VehicleAggregate vehicle = _service.GetVehicleById(id); // TODO: Catch exception
            return Ok(vehicle);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VehicleAggregate request) // TODO: Change to CreateVehicleDto
        {
            VehicleAggregate createdVehicle = _service.CreateVehicle(request); // TODO: Catch exception?
            return CreatedAtAction(nameof(GetById), new { id = createdVehicle.Id }, createdVehicle);
        }

        [HttpPut("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string request) // TODO: Change to UpdateVehicleStatusDto
        {
            _service.UpdateVehicleStatus(id, request); // TODO: Catch exception
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteVehicle(id); // TODO: Catch exception
            return NoContent();
        }
    }
}
