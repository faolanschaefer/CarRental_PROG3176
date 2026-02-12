using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Aggregates;

namespace VehicleInventory.Application.Services;

// TODO: Refactor to use domain services and aggregate roots 
public class VehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public VehicleAggregate CreateVehicle(VehicleAggregate vehicle)
    {
        return _repository.Create(vehicle);
    }

    public VehicleAggregate GetVehicleById(int id)
    {
        return _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Vehicle with ID {id} not found.");
    }

    public IEnumerable<VehicleAggregate> GetAllVehicles()
    {
        return _repository.GetAll();
    }

    public void UpdateVehicleStatus(int id, string status)
    {
        VehicleAggregate vehicle = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Vehicle with ID {id} not found.");

        switch (status)
        {
            case "Available":
                vehicle.MarkAvailable();
                break;
            case "Reserved":
                vehicle.MarkReserved();
                break;
            case "Rented":
                vehicle.MarkRented();
                break;
            case "Maintenance":
                vehicle.MarkMaintenance();
                break;
            default:
                throw new ArgumentException($"{status} is not a valid Status.");
        }

        _repository.Update(vehicle);
    }

    // TODO: Implement UpdateVehicleLocation and UpdateVehicle methods?

    public void ReleaseVehicleReservation(int id)
    {
        VehicleAggregate vehicle = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Vehicle with ID {id} not found.");

        vehicle.ReleaseReservation();

        _repository.Update(vehicle);
    }

    public void DeleteVehicle(int id)
    {
        _repository.Delete(id);
    }
}