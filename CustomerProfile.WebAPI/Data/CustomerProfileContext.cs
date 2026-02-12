using CustomerProfile.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerProfile.WebAPI.Data;

public partial class CustomerProfileContext : DbContext
{
    public CustomerProfileContext()
    {
    }

    public CustomerProfileContext(DbContextOptions<CustomerProfileContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CustomerProfileDb; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC070EB8DF68");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
