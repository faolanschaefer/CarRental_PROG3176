using VehicleInventory.Domain.Entities;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Infrastructure.Models;

namespace VehicleInventory.Infrastructure.Mappers
{
    internal static class VehicleMapper
    {

        private static Inventory MapToDomain(Inventory8878889 inventoryDb)
        {
            return new Inventory
            {
                Id = inventoryDb.Id,
                Vehicle = MapToDomain(inventoryDb.Vehicle),
                VehicleLocation = MapToDomain(inventoryDb.VehicleLocation),
                VehicleStatus = MapToDomain(inventoryDb.VehicleStatus),
                LastUpdated = inventoryDb.LastUpdated
            };
        }

        private static Vehicle MapToDomain(Vehicle8878889 vehicleDb)
        {
            return new Vehicle
            {
                Id = vehicleDb.Id,
                Make = vehicleDb.Make,
                Model = vehicleDb.Model,
                VehicleType = MapToDomain(vehicleDb.VehicleType)
            };
        }
        private static Domain.Entities.VehicleType MapToDomain(VehicleType8878889 vehicleTypeDb)
        {
            return new Domain.Entities.VehicleType
            {
                Id = vehicleTypeDb.Id,
                Name = vehicleTypeDb.Name
            };
        }
        private static VehicleLocation MapToDomain(VehicleLocation8878889 locationDb)
        {
            return new VehicleLocation
            {
                Id = locationDb.Id,
                Name = locationDb.Name
            };
        }
        private static VehicleStatus MapToDomain(VehicleStatus8878889 statusDb)
        {
            return Enum.Parse<VehicleStatus>(statusDb.Name);
        }
    }
}