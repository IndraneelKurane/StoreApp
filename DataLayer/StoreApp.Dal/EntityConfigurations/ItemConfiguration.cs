using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations;
public class ItemConfiguration : EntityConfigurationBase<ItemEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemEntity> builder)
    {
        base.Configure(builder);
        builder.ToTable("Item");
        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(i => i.Price)
            .IsRequired();

        // Configure relationships
        builder.HasOne(i => i.Unit)
            .WithMany(u => u.Items)
            .HasForeignKey(i => i.UnitId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(i => i.Location)
            .WithMany(u => u.Items)
            .HasForeignKey(i => i.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(i => i.Unit).AutoInclude();
        builder.Navigation(i => i.Location).AutoInclude();

        builder.HasData(ItemSeeder.GetSeedData());
    }
}
