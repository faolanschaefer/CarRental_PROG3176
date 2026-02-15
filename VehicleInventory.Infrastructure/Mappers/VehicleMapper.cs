using VehicleInventory.Domain.Aggregates;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Infrastructure.Models;
using VehicleInventory.Domain.ValueObjects;

namespace VehicleInventory.Infrastructure.Mappers
{
    internal static class VehicleMapper
    {
        internal static Inventory8878889 VehicleAggregateToInventory(VehicleAggregate vehicle)
            => new Inventory8878889
            {
                Id = vehicle.Id,
                VehicleId = vehicle.Details.VehicleId,
                VehicleLocationId = vehicle.LocationId,
                VehicleStatusId = StatusToId(vehicle.Status),
                LastUpdated = DateTime.UtcNow
            };

        internal static VehicleAggregate InventoryToVehicleAggregate(Inventory8878889 inventory)
            => VehicleAggregate.Reconstitute
            (
                id: inventory.Id,
                details: new VehicleDetails(
                    vehicleId: inventory.VehicleId,
                    make: inventory.Vehicle.Make,
                    model: inventory.Vehicle.Model,
                    vehicleType: IdToType(inventory.Vehicle.VehicleTypeId)
                ),
                locationId: inventory.VehicleLocationId,
                status: IdToStatus(inventory.VehicleStatusId)
            );

        internal static VehicleStatus IdToStatus(int vehicleStatusId)
            => vehicleStatusId switch
            {
                1 => VehicleStatus.Available,
                2 => VehicleStatus.Reserved,
                3 => VehicleStatus.Rented,
                4 => VehicleStatus.Maintenance,
                _ => throw new ArgumentException($"Invalid VehicleStatusId: {vehicleStatusId}")
            };

        internal static int StatusToId(VehicleStatus status)
            => status switch
            {
                VehicleStatus.Available => 1,
                VehicleStatus.Reserved => 2,
                VehicleStatus.Rented => 3,
                VehicleStatus.Maintenance => 4,
                _ => throw new ArgumentException($"Invalid VehicleStatus: {status}")
            };

        internal static VehicleType IdToType(int vehicleTypeId)
            => vehicleTypeId switch
            {
                1 => VehicleType.Sedan,
                2 => VehicleType.SUV,
                3 => VehicleType.Truck,
                4 => VehicleType.Van,
                _ => throw new ArgumentException($"Invalid VehicleTypeId: {vehicleTypeId}")
            };

        internal static int TypeToId(VehicleType type)
            => type switch
            {
                VehicleType.Sedan => 1,
                VehicleType.SUV => 2,
                VehicleType.Truck => 3,
                VehicleType.Van => 4,
                _ => throw new ArgumentException($"Invalid VehicleType: {type}")
            };
    }
}