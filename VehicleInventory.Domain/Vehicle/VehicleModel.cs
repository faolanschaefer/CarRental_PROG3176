namespace VehicleInventory.Domain.Vehicle
{
    public class VehicleModel
    {
        public string Value { get; private set; }

        public VehicleModel(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Model cannot be empty.", nameof(value));
            Value = value;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not VehicleModel other) return false;
            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode() => Value.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}
