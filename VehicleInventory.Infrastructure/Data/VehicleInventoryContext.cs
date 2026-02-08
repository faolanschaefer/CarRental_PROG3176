using Microsoft.EntityFrameworkCore;
using VehicleInventory.Infrastructure.Models;

namespace VehicleInventory.Infrastructure.Data;

public partial class VehicleInventoryContext : DbContext
{
    public VehicleInventoryContext()
    {
    }

    public VehicleInventoryContext(DbContextOptions<VehicleInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory8878889> Inventory8878889s { get; set; }

    public virtual DbSet<Vehicle8878889> Vehicle8878889s { get; set; }

    public virtual DbSet<VehicleLocation8878889> VehicleLocation8878889s { get; set; }

    public virtual DbSet<VehicleStatus8878889> VehicleStatus8878889s { get; set; }

    public virtual DbSet<VehicleType8878889> VehicleType8878889s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=VehicleInventoryDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory8878889>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Inventor__3214EC07098A392A");

            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(sysdatetime())");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Inventory8878889s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Vehicle");

            entity.HasOne(d => d.VehicleLocation).WithMany(p => p.Inventory8878889s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_VehicleLocation");

            entity.HasOne(d => d.VehicleStatus).WithMany(p => p.Inventory8878889s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_VehicleStatus");
        });

        modelBuilder.Entity<Vehicle8878889>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehicle___3214EC0711D833DE");

            entity.HasOne(d => d.VehicleType).WithMany(p => p.Vehicle8878889s)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vehicle_VehicleType");
        });

        modelBuilder.Entity<VehicleLocation8878889>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleL__3214EC07EED8863D");
        });

        modelBuilder.Entity<VehicleStatus8878889>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleS__3214EC07FC0065A9");
        });

        modelBuilder.Entity<VehicleType8878889>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleT__3214EC0766491C06");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
