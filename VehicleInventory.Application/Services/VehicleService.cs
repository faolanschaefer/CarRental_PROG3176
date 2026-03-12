using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Vehicle;

namespace VehicleInventory.Application.Services;

public class VehicleService: IVehicleService
{
    private readonly IVehicleRepository _repository;

    public VehicleService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public VehicleDto CreateVehicle(CreateVehicleDto dto)
    {
        VehicleDetails details = _repository.GetVehicleDetails(dto.VehicleId)
            ?? throw new KeyNotFoundException($"Vehicle details with ID {dto.VehicleId} not found.");

        Vehicle vehicle = Vehicle.Create(details, dto.LocationId);
        Vehicle createdVehicle = _repository.Create(vehicle);

        return MapToDto(createdVehicle);
    }

    public VehicleDto GetVehicleById(int id)
    {
        if (id <= 0)
            throw new ArgumentException("ID must be greater than zero.", nameof(id));
        Vehicle vehicle = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Vehicle with ID {id} not found.");

        return MapToDto(vehicle);
    }

    public IEnumerable<VehicleDto> GetAllVehicles()
    {
        IEnumerable<Vehicle> vehicles = _repository.GetAll();
        return vehicles.Select(MapToDto);
    }

    public void UpdateVehicleStatus(int id, UpdateVehicleStatusDto dto)
    {
        Vehicle vehicle = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Vehicle with ID {id} not found.");

        switch (dto.Status)
        {
            case VehicleStatus.Available:
                vehicle.MarkAvailable();
                break;
            case VehicleStatus.Reserved:
                vehicle.MarkReserved();
                break;
            case VehicleStatus.Rented:
                vehicle.MarkRented();
                break;
            case VehicleStatus.Maintenance:
                vehicle.MarkMaintenance();
                break;
            default:
                throw new ArgumentException($"{dto.Status} is not a valid Status.");
        }

        _repository.Update(vehicle);
    }

    public void ReleaseVehicleReservation(int id)
    {
        Vehicle vehicle = _repository.GetById(id)
            ?? throw new KeyNotFoundException($"Vehicle with ID {id} not found.");

        vehicle.ReleaseReservation();

        _repository.Update(vehicle);
    }

    public void DeleteVehicle(int id)
    {
        _repository.Delete(id);
    }

    private static VehicleDto MapToDto(Vehicle vehicle)
    {
        return new VehicleDto
        {
            Id = vehicle.Id,
            VehicleId = vehicle.Details.VehicleId,
            Make = vehicle.Details.Make.Value,
            Model = vehicle.Details.Model.Value,
            LocationId = vehicle.LocationId,
            VehicleType = vehicle.Details.Type.ToString(),
            Status = vehicle.Status.ToString()
        };
    }
}