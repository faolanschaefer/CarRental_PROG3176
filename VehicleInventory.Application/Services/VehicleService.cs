using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Entities;
using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Application.Services;

// TODO: Refactor to use domain services and aggregate roots 
public class VehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public Inventory CreateVehicle(Inventory vehicle)
    {
        return _repository.Create(vehicle);
    }

    public Inventory GetVehicleById(int id)
    {
        return _repository.GetById(id);
    }

    public IEnumerable<Inventory> GetAllVehicles()
    {
        return _repository.GetAll();
    }

    public void UpdateVehicleStatus(int id, string status)
    {
        var vehicle = _repository.GetById(id);
        if (vehicle == null)
        {
            throw new Exception("Vehicle not found");
        }
        vehicle.VehicleStatus = Enum.Parse<VehicleStatus>(status); // TODO: Handle status via aggregate root/domain entity
        _repository.Update(vehicle);
    }

    public void DeleteVehicle(int id)
    {
        _repository.Delete(id);
    }
}