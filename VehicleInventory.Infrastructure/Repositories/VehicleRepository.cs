using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Infrastructure.Data;
using VehicleInventory.Infrastructure.Mappers;

namespace VehicleInventory.Infrastructure.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleInventoryContext _context;
        
        public VehicleRepository(VehicleInventoryContext context)
        {
            _context = context;
        }
        
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            var dbVehicle = await _context.Inventory8878889s
                .Include(i => i.Vehicle)
                .Include(i => i.VehicleStatus)
                .FirstOrDefaultAsync(i => i.Id == id);
            
            return DomainMapper.MapToDomain(dbVehicle);
        }
    }
}
