using VehicleInventory.Application.Interfaces;
using VehicleInventory.Infrastructure.Data;
using VehicleInventory.Domain.Entities;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public Inventory GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Inventory vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
