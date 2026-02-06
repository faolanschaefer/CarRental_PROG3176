using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VehicleInventory.Infrastructure.Models;

[Table("VehicleLocation_8878889")]
[Index("Name", Name = "UQ__VehicleL__737584F6A9DE75DE", IsUnique = true)]
public partial class VehicleLocation8878889
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("VehicleLocation")]
    public virtual ICollection<Inventory8878889> Inventory8878889s { get; set; } = new List<Inventory8878889>();
}
