using VehicleInventory.Domain.Aggregates;
using VehicleInventory.Domain.ValueObjects;
using VehicleInventory.Infrastructure.Models;

namespace VehicleInventory.Infrastructure.Mappers
{
    public static class DomainMapper
    {
        public static Vehicle MapToDomain(Inventory8878889 dbEntity)
        {
            return new Vehicle(
                id: dbEntity.Id,
                vehicleCode: $"{dbEntity.Vehicle.Make}-{dbEntity.Vehicle.Model}",
                locationId: dbEntity.VehicleLocationId,
                vehicleType: new VehicleType(dbEntity.Vehicle.Make, dbEntity.Vehicle.Model),
                status: MapStatus(dbEntity.VehicleStatus.Name)
            );
        }

        public static VehicleStatus MapStatus(string statusName)
        {
            return statusName switch
            {
                "Available" => VehicleStatus.Available,
                "Reserved" => VehicleStatus.Reserved,
                "Rented" => VehicleStatus.Rented,
                "Serviced" => VehicleStatus.Serviced,
                _ => throw new ArgumentException($"Unknown status name: {statusName}")
            };
        }
    }
}
