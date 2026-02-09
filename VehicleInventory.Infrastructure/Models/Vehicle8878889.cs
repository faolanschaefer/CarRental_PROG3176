using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleInventory.Infrastructure.Models;

[Table("Vehicle_8878889")]
public partial class Vehicle8878889
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Make { get; set; } = null!;

    [StringLength(50)]
    public string Model { get; set; } = null!;

    public int VehicleTypeId { get; set; }

    [InverseProperty("Vehicle")]
    public virtual ICollection<Inventory8878889> Inventory { get; set; } = new List<Inventory8878889>();

    [ForeignKey("VehicleTypeId")]
    [InverseProperty("Vehicles")]
    public virtual VehicleType8878889 VehicleType { get; set; } = null!;
}
