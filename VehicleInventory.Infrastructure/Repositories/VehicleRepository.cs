using VehicleInventory.Application.Interfaces;
using VehicleInventory.Infrastructure.Data;
using VehicleInventory.Domain.Entities;
using VehicleInventory.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Infrastructure.Repositories
{
    // TODO: Implement methods using VehicleInventoryContext
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleInventoryContext _context;

        public VehicleRepository(VehicleInventoryContext context)
        {
            _context = context;
        }

        public Inventory Create(Inventory vehicle)
        {
            var createdVehicle = _context.Vehicles.Add(MapToDb(vehicle.Vehicle)).Entity;
            vehicle.Vehicle.Id = createdVehicle.Id;
            var createdInventory = _context.Inventory.Add(MapToDb(vehicle)).Entity;

            _context.SaveChanges();
            return MapToDomain(createdInventory);
        }

        public void Delete(int id)
        {
            var inventory = _context.Inventory.Find(id);
            if (inventory != null)
            {
                var vehicle = _context.Vehicles.Find(inventory.VehicleId);
                if (vehicle != null)
                {
                    _context.Vehicles.Remove(vehicle);
                    _context.Inventory.Remove(inventory);

                    _context.SaveChanges();
                }
                else throw new Exception($"Vehicle with ID {inventory.VehicleId} not found.");
                // TODO: Specify exception type
            }
            else throw new Exception($"Inventory with ID {id} not found."); // TODO: Specify exception type
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _context.Inventory
                .Include(i => i.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(i => i.VehicleLocation)
                .Include(i => i.VehicleStatus)
                .Select(inventoryDb => MapToDomain(inventoryDb))
                .ToList();
        }

        public Inventory GetById(int id)
        {
            var inventoryDb = _context.Inventory
                .Include(i => i.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(i => i.VehicleLocation)
                .Include(i => i.VehicleStatus)
                .FirstOrDefault(i => i.Id == id);
            if (inventoryDb == null)
            {
                throw new Exception($"Inventory with ID {id} not found."); // TODO: Specify exception type
            }
            return MapToDomain(inventoryDb);
        }

        public void Update(Inventory vehicle)
        {
            var inventoryDb = _context.Inventory.Find(vehicle.Id);
            if (inventoryDb == null)
            {
                throw new Exception($"Inventory with ID {vehicle.Id} not found."); // TODO: Specify exception type
            }
            inventoryDb.VehicleId = vehicle.Vehicle.Id;
            inventoryDb.LastUpdated = vehicle.LastUpdated; // TODO: UTC now? Where is this updated?
            inventoryDb.VehicleLocationId = vehicle.VehicleLocation.Id; // TODO: Validate?
            inventoryDb.VehicleStatusId = MapToDb(vehicle.VehicleStatus).Id; // TODO: Validate?

            var vehicleDb = _context.Vehicles.Find(vehicle.Vehicle.Id);
            if (vehicleDb == null)
            {
                throw new Exception($"Vehicle with ID {vehicle.Vehicle.Id} not found."); // TODO: Specify exception type
            }
            vehicleDb.Make = vehicle.Vehicle.Make;
            vehicleDb.Model = vehicle.Vehicle.Model;
            vehicleDb.VehicleTypeId = vehicle.Vehicle.VehicleType.Id; // TODO: Validate?

            _context.SaveChanges();
        }

        private Inventory8878889 MapToDb(Inventory vehicle)
        {
            return new Inventory8878889
            {
                Id = vehicle.Id,
                VehicleId = vehicle.Vehicle.Id,
                VehicleLocationId = vehicle.VehicleLocation.Id,
                VehicleStatusId = MapToDb(vehicle.VehicleStatus).Id,
                LastUpdated = vehicle.LastUpdated
            };
        }

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

        private Vehicle8878889 MapToDb(Vehicle vehicle)
        {
            return new Vehicle8878889
            {
                Id = vehicle.Id,
                Make = vehicle.Make,
                Model = vehicle.Model,
                VehicleTypeId = vehicle.VehicleType.Id
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

        private VehicleStatus8878889 MapToDb(VehicleStatus status)
        {
            var statusDb = _context.VehicleStatuses.FirstOrDefault(s => s.Name == status.ToString());
            if (statusDb == null)
            {
                throw new Exception($"VehicleStatus '{status}' not found in database."); // TODO: Specify exception type
            }
            return statusDb;
        }
    }
}
