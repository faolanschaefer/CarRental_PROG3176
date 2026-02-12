using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.ValueObjects;

namespace VehicleInventory.Domain.Aggregates
{
    public class VehicleAggregate
    {
        public int Id { get; private set; }
        public int VehicleId { get; private set; }
        public VehicleMake Make { get; private set; }
        public VehicleModel Model { get; private set; }
        public int LocationId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public VehicleStatus Status { get; private set; }

        public VehicleAggregate(int id, int vehicleId, VehicleMake make, VehicleModel model, int locationId, VehicleType vehicleType, VehicleStatus status)
        {
            Id = id;
            VehicleId = vehicleId;
            Make = make;
            Model = model;
            LocationId = locationId;
            VehicleType = vehicleType;
            Status = status;
        }

        public void MarkAvailable()
        {
            if (Status == VehicleStatus.Reserved)
                throw new InvalidOperationException("Cannot mark a reserved vehicle as available without explicit release.");

            Status = VehicleStatus.Available;
        }

        public void ReleaseReservation()
        {
            if (Status != VehicleStatus.Reserved)
                throw new InvalidOperationException("Only reserved vehicles can be released.");

            Status = VehicleStatus.Available;
        }

        public void MarkReserved() => Status = VehicleStatus.Reserved;

        public void MarkMaintenance() => Status = VehicleStatus.Maintenance;

        public void MarkRented()
        {
            if (Status == VehicleStatus.Rented)
                throw new InvalidOperationException("Vehicle is already rented.");

            if (Status == VehicleStatus.Reserved)
                throw new InvalidOperationException("Cannot rent a reserved vehicle.");

            if (Status == VehicleStatus.Maintenance)
                throw new InvalidOperationException("Cannot rent a vehicle under service.");

            Status = VehicleStatus.Rented;
        }
    }
}
