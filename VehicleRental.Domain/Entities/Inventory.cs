using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Domain.Entities
{
    public class Inventory
    {
        public int Id { get; set; }

        public DateTime LastUpdated { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

        public VehicleLocation VehicleLocation { get; set; } = null!;

        public VehicleStatus VehicleStatus { get; set; }
    }
}
