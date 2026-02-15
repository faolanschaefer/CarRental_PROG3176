using System.ComponentModel.DataAnnotations;
using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Application.DTOs
{
    public class UpdateVehicleStatusDto
    {
        [Required(ErrorMessage = "Status is required")]
        public VehicleStatus Status { get; set; }
    }
}
