using VehicleInventory.Domain.Aggregates;
using VehicleInventory.Domain.ValueObjects;
using VehicleInventory.Infrastructure.Models;

namespace VehicleInventory.Infrastructure.Mappers
{
    public static class VehicleMapper
    {
        public static Vehicle MapDbToDomain(Inventory8878889 dbEntity)
        {
            return new Vehicle(
                id: dbEntity.Id,
                vehicleCode: $"{dbEntity.Vehicle.Make}-{dbEntity.Vehicle.Model}",
                locationId: dbEntity.VehicleLocationId,
                vehicleType: new VehicleType(dbEntity.Vehicle.Make, dbEntity.Vehicle.Model),
                status: MapStatus(dbEntity.VehicleStatus.Name)
            );
        }

        private static VehicleStatus MapStatus(string statusName)
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

        internal static Inventory8878889 MapDomainToDb(Vehicle vehicle)
        {
            return new Inventory8878889
            {
                Id = vehicle.Id,
                VehicleLocationId = vehicle.LocationId,
                Vehicle = new Vehicle8878889
                {
                    Make = vehicle.VehicleType.Make,
                    Model = vehicle.VehicleType.Model
                },
                VehicleStatus = new VehicleStatus8878889
                {
                    Name = vehicle.Status.ToString()
                }
            };
        }
    }
}
