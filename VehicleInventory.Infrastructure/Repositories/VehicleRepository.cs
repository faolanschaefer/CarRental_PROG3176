using VehicleInventory.Application.Interfaces;
using VehicleInventory.Infrastructure.Data;
using VehicleInventory.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.Aggregates;
using VehicleInventory.Infrastructure.Models;

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

        public VehicleAggregate Create(VehicleAggregate vehicle)
        {
            var createdInventory = _context.Inventory.Add(VehicleMapper.MapToDb(vehicle)).Entity;
            _context.SaveChanges();

            return VehicleMapper.MapToDomain(createdInventory);
        }

        public void Delete(int id)
        {
            Inventory8878889 inventory = _context.Inventory.Find(id)
                ?? throw new Exception($"Inventory with ID {id} not found."); // TODO: Specify exception type

            Vehicle8878889 vehicle = _context.Vehicles.Find(inventory.VehicleId)
                ?? throw new Exception($"Vehicle with ID {inventory.VehicleId} not found."); // TODO: Specify exception type

            _context.Vehicles.Remove(vehicle);
            _context.Inventory.Remove(inventory);

            _context.SaveChanges();
        }

        public IEnumerable<VehicleAggregate> GetAll()
        {
            return _context.Inventory
                .Include(i => i.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(i => i.VehicleLocation)
                .Include(i => i.VehicleStatus)
                .Select(inventoryDb => VehicleMapper.MapToDomain(inventoryDb))
                .ToList();
        }

        public VehicleAggregate GetById(int id)
        {
            Inventory8878889 inventory = _context.Inventory
                .Include(i => i.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(i => i.VehicleLocation)
                .Include(i => i.VehicleStatus)
                .FirstOrDefault(i => i.Id == id)
                ?? throw new Exception($"Inventory with ID {id} not found."); // TODO: Specify exception type

            return VehicleMapper.MapToDomain(inventory);
        }

        public void Update(VehicleAggregate vehicle)
        {
            Inventory8878889 inventory = _context.Inventory.Find(vehicle.Id)
                ?? throw new Exception($"Inventory with ID {vehicle.Id} not found."); // TODO: Specify exception type

            inventory.VehicleId = vehicle.VehicleId;
            inventory.VehicleLocationId = vehicle.LocationId;
            inventory.VehicleStatusId = (int)vehicle.Status;
            inventory.LastUpdated = DateTime.UtcNow;

            _context.SaveChanges();
        }
    }
}
