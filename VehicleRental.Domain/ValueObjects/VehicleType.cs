namespace VehicleInventory.Domain.ValueObjects
{
    public class VehicleType
    {
        public string Make { get; private set; }
        public string Model { get; private set; }
        public VehicleType(string make, string model)
        {
            Make = make;
            Model = model;
        }
    }
}
