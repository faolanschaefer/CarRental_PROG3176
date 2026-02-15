using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.ValueObjects;

namespace VehicleInventory.Domain.Aggregates
{
    public class VehicleAggregate
    {
        public int Id { get; private set; }
        public VehicleDetails Details { get; private set; }
        public int LocationId { get; private set; }
        public VehicleStatus Status { get; private set; }

        private VehicleAggregate() { }

        public static VehicleAggregate Create(VehicleDetails details, int locationId)
        {
            if (details is null)
                throw new ArgumentNullException(nameof(details));
            if (locationId <= 0)
                throw new ArgumentException("Location ID must be a positive integer.", nameof(locationId));

            return new VehicleAggregate
            {
                Details = details,
                LocationId = locationId,
                Status = VehicleStatus.Available
            };
        }

        public static VehicleAggregate Reconstitute(int id, VehicleDetails details, int locationId, VehicleStatus status)
        {
            return new VehicleAggregate
            {
                Id = id,
                Details = details,
                LocationId = locationId,
                Status = status
            };
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
