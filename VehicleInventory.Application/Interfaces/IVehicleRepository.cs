using VehicleInventory.Domain.Entities;

namespace VehicleInventory.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Inventory Create(Inventory vehicle);
        Inventory GetById(int id);
        IEnumerable<Inventory> GetAll();
        void Update(Inventory vehicle);
        void Delete(int id);

    }
}
