namespace VehicleInventory.Domain.ValueObjects
{
    public class VehicleModel
    {
        private string _value;

        public VehicleModel(string value)
        {
            _value = value; // TODO: Validate
        }

        public override string ToString() => _value;
    }
}
