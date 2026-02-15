using VehicleInventory.Application.Interfaces;
using VehicleInventory.Infrastructure.Data;
using VehicleInventory.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Domain.Aggregates;
using VehicleInventory.Infrastructure.Models;
using VehicleInventory.Domain.ValueObjects;

namespace VehicleInventory.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleInventoryContext _context;

        public VehicleRepository(VehicleInventoryContext context)
        {
            _context = context;
        }

        public VehicleAggregate Create(VehicleAggregate vehicle)
        {
            Inventory8878889 createdInventory = _context.Inventory.Add(VehicleMapper.VehicleAggregateToInventory(vehicle)).Entity;
            _context.SaveChanges();

            return VehicleMapper.InventoryToVehicleAggregate(createdInventory);
        }

        public void Delete(int id)
        {
            Inventory8878889 inventory = _context.Inventory.Find(id)
                ?? throw new KeyNotFoundException($"Inventory with ID {id} not found."); 

            _context.Inventory.Remove(inventory);

            _context.SaveChanges();
        }

        public IEnumerable<VehicleAggregate> GetAll()
        {
            return _context.Inventory
                .Include(i => i.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Select(i => VehicleMapper.InventoryToVehicleAggregate(i))
                .ToList();
        }

        public VehicleAggregate? GetById(int id)
        {
            Inventory8878889? inventory = _context.Inventory
                .Include(i => i.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .FirstOrDefault(i => i.Id == id);

            if (inventory is null) return null;

            return VehicleMapper.InventoryToVehicleAggregate(inventory);
        }

        public void Update(VehicleAggregate vehicle)
        {
            Inventory8878889 inventory = _context.Inventory.Find(vehicle.Id)
                ?? throw new KeyNotFoundException($"Inventory with ID {vehicle.Id} not found."); 

            inventory.VehicleId = vehicle.Details.VehicleId;
            inventory.VehicleLocationId = vehicle.LocationId;
            inventory.VehicleStatusId = VehicleMapper.StatusToId(vehicle.Status);
            inventory.LastUpdated = DateTime.UtcNow;

            _context.SaveChanges();
        }

        public VehicleDetails? GetVehicleDetails(int vehicleId)
        {
            Vehicle8878889? vehicle = _context.Vehicles.Find(vehicleId)
                ?? throw new KeyNotFoundException($"Vehicle with ID {vehicleId} not found.");

            return new VehicleDetails(vehicle.Id, vehicle.Make, vehicle.Model, VehicleMapper.IdToType(vehicle.VehicleTypeId));
        }
    }
}
