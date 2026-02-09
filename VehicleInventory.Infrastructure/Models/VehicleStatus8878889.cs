using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VehicleInventory.Infrastructure.Models;

[Table("VehicleStatus_8878889")]
[Index("Name", Name = "UQ__VehicleS__737584F6A5ADDC25", IsUnique = true)]
public partial class VehicleStatus8878889
{
    [Key]
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; } = null!;

    [InverseProperty("VehicleStatus")]
    public virtual ICollection<Inventory8878889> Inventory { get; set; } = new List<Inventory8878889>();
}
