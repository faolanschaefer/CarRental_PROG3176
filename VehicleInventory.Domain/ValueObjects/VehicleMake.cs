namespace VehicleInventory.Domain.ValueObjects
{
    public class VehicleMake
    {
        private string _value;

        public VehicleMake(string value)
        {
            _value = value; // TODO: Validate
        }

        public override string ToString() => _value;
    }
}
