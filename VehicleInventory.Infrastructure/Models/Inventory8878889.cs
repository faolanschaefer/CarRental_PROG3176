using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleInventory.Infrastructure.Models;

[Table("Inventory_8878889")]
public partial class Inventory8878889
{
    [Key]
    public int Id { get; set; }

    public int VehicleId { get; set; }

    public int VehicleLocationId { get; set; }

    public int VehicleStatusId { get; set; }

    public DateTime LastUpdated { get; set; }

    [ForeignKey("VehicleId")]
    [InverseProperty("Inventory")]
    public virtual Vehicle8878889 Vehicle { get; set; } = null!;

    [ForeignKey("VehicleLocationId")]
    [InverseProperty("Inventory")]
    public virtual VehicleLocation8878889 VehicleLocation { get; set; } = null!;

    [ForeignKey("VehicleStatusId")]
    [InverseProperty("Inventory")]
    public virtual VehicleStatus8878889 VehicleStatus { get; set; } = null!;
}
