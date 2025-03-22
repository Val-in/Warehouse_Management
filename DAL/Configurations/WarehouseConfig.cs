using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(w => w.Name).IsRequired().HasMaxLength(100); 
        builder.Property(w => w.Location).HasMaxLength(200);
        
        builder.HasMany(w => w.Employees)
            .WithOne(e => e.Warehouse)
            .HasForeignKey(e => e.WarehouseId);
        
        builder.HasMany(w => w.Products)
            .WithOne(p => p.Warehouse)
            .HasForeignKey(p => p.WarehouseId);
    }
}
