using VehicleInventory.Domain.Aggregates;
using VehicleInventory.Domain.ValueObjects;

namespace VehicleInventory.Application.Interfaces
{
    public interface IVehicleRepository
    {
        VehicleAggregate Create(VehicleAggregate vehicle);
        VehicleAggregate? GetById(int id);
        IEnumerable<VehicleAggregate> GetAll();
        void Update(VehicleAggregate vehicle);
        void Delete(int id);
        VehicleDetails? GetVehicleDetails(int vehicleId);
    }
}
