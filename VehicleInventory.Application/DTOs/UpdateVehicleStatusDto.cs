using System.ComponentModel.DataAnnotations;
using VehicleInventory.Domain.Vehicle;

namespace VehicleInventory.Application.DTOs
{
    public class UpdateVehicleStatusDto
    {
        [Required(ErrorMessage = "Status is required")]
        public VehicleStatus Status { get; set; }
    }
}
