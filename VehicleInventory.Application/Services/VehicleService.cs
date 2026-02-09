using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;

namespace VehicleInventory.Application.Services;

// TODO: Implement methods using VehicleRepository
public class VehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public VehicleDto CreateVehicle(int id, string status)
    {
        throw new NotImplementedException();
    }

    public VehicleDto GetVehicleById(int id, string status)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<VehicleDto> GetAllVehicles(int id, string status)
    {
        throw new NotImplementedException();
    }

    public void UpdateVehicleStatus(int id, string status)
    {
        throw new NotImplementedException();
    }

    public void DeleteVehicle(int id, string status)
    {
        throw new NotImplementedException();
    }
}