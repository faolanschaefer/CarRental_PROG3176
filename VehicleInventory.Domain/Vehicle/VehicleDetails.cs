namespace VehicleInventory.Domain.Vehicle
{
    public class VehicleDetails
    {
        public int VehicleId { get; private set; }
        public VehicleMake Make { get; private set; }
        public VehicleModel Model { get; private set; }
        public VehicleType Type { get; private set; }

        public VehicleDetails(int vehicleId, string make, string model, VehicleType type)
        {
            VehicleId = vehicleId;
            Make = new(make);
            Model = new(model);
            Type = type;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not VehicleDetails other) return false;

            return VehicleId == other.VehicleId
                && Make.Equals(other.Make)
                && Model.Equals(other.Model)
                && Type == other.Type;
        }

        public override int GetHashCode() => HashCode.Combine(VehicleId, Make, Model, Type);
    }
}
