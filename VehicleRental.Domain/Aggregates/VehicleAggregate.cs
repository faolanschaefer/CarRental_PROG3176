using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Domain.Aggregates
{
    public class VehicleAggregate
    {
        public int Id { get; private set; }
        public int VehicleId{ get; private set; }
        public int LocationId { get; private set; }
        public VehicleType VehicleType { get; private set; }
        public VehicleStatus VehicleStatus { get; private set; }
        public VehicleAggregate(int id, int vehicleId, int locationId, VehicleType vehicleType, VehicleStatus vehicleStatus)
        {
            Id = id;
            VehicleId = vehicleId;
            LocationId = locationId;
            VehicleType = vehicleType;
            VehicleStatus = vehicleStatus;
        }
        public void MarkAvailable()
        {
            if (VehicleStatus == VehicleStatus.Reserved)
                throw new InvalidOperationException("Cannot mark a reserved vehicle as available without explicit release.");

            VehicleStatus = VehicleStatus.Available;
        }

        public void ReleaseReservation()
        {
            if (VehicleStatus != VehicleStatus.Reserved)
                throw new InvalidOperationException("Only reserved vehicles can be released.");

            VehicleStatus = VehicleStatus.Available;
        }

        public void MarkReserved() => VehicleStatus = VehicleStatus.Reserved;
        public void MarkServiced() => VehicleStatus = VehicleStatus.Maintenance;
        public void MarkRented()
        {
            if (VehicleStatus == VehicleStatus.Rented)
                throw new InvalidOperationException("Vehicle is already rented.");

            if (VehicleStatus == VehicleStatus.Reserved)
                throw new InvalidOperationException("Cannot rent a reserved vehicle.");

            if (VehicleStatus == VehicleStatus.Maintenance)
                throw new InvalidOperationException("Cannot rent a vehicle under service.");

            VehicleStatus = VehicleStatus.Rented;
        }
    }
}
