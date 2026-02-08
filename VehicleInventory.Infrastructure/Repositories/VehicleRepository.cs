using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using VehicleInventory.Infrastructure.Data;
using VehicleInventory.Infrastructure.Mappers;
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

        public Vehicle Create(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
