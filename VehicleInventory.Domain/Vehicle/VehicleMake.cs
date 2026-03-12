namespace VehicleInventory.Domain.Vehicle
{
    public class VehicleMake
    {
        public string Value { get; private set; }

        public VehicleMake(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Make cannot be empty.", nameof(value));
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not VehicleMake other) return false;
            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() => Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}
