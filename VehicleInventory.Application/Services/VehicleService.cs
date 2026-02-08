using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;

namespace VehicleInventory.Application.Services;

public class VehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<VehicleDto> RentVehicleAsync(int vehicleId)
    {
        Vehicle vehicle = await _repository.GetByIdAsync(vehicleId);
        
        // Call domain behavior (enforces rules)
        vehicle.MarkRented();
        
        await _repository.UpdateAsync(vehicle);
        
        return MapToDto(vehicle);
    }
}