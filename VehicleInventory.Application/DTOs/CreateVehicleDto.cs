using System.ComponentModel.DataAnnotations;

namespace VehicleInventory.Application.DTOs
{
    public class CreateVehicleDto
    {
        [Required(ErrorMessage = "Vehicle ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Vehicle ID must be positive")]
        public int VehicleId { get; set; }  // Reference to existing Vehicle

        [Required(ErrorMessage = "Location ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Location ID must be positive")]
        public int LocationId { get; set; }
    }
}
