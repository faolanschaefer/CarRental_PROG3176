using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace VehicleInventory.Infrastructure.Models;

[Table("VehicleType_8878889")]
[Index("Name", Name = "UQ__VehicleT__737584F691AD750D", IsUnique = true)]
public partial class VehicleType8878889
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [InverseProperty("VehicleType")]
    public virtual ICollection<Vehicle8878889> Vehicle8878889s { get; set; } = new List<Vehicle8878889>();
}
