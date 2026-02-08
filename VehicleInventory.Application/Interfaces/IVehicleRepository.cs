using VehicleInventory.Domain.Aggregates;

namespace VehicleInventory.Application.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle Create(Vehicle vehicle);
        Vehicle GetById(int id);
        IEnumerable<Vehicle> GetAll();
        void Update(Vehicle vehicle);
        void Delete(int id);

    }
}
