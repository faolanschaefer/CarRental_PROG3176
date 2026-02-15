namespace VehicleInventory.Application.DTOs
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int LocationId { get; set; }
        public string VehicleType { get; set; }
        public string Status { get; set; }
    }
}
