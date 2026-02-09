namespace VehicleInventory.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public VehicleType VehicleType { get; set; } = null!;
    }
}
