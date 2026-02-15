using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Domain.ValueObjects
{
    public class VehicleDetails
    {
        public int VehicleId { get; private set; }
        public string Make { get; private set; }
        public string Model { get; private set; }
        public VehicleType VehicleType { get; private set; }

        public VehicleDetails(int vehicleId, string make, string model, VehicleType vehicleType)
        {
            if (vehicleId <= 0)
                throw new ArgumentException("Vehicle ID must be a positive integer.", nameof(vehicleId));
            if (string.IsNullOrWhiteSpace(make))
                throw new ArgumentException("Make cannot be empty.", nameof(make));
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Model cannot be empty.", nameof(model));

            VehicleId = vehicleId;
            Make = make;
            Model = model;
            VehicleType = vehicleType;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not VehicleDetails other) return false;

            return VehicleId == other.VehicleId
                && Make == other.Make
                && Model == other.Model
                && VehicleType == other.VehicleType;
        }

        public override int GetHashCode() => HashCode.Combine(VehicleId, Make, Model, VehicleType);
    }
}
