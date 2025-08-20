using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations;
public class LocationRowConfiguration : EntityConfigurationBase<LocationRowEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LocationRowEntity> builder)
    {
        base.Configure(builder);
        builder.ToTable("LocationRow");
        builder.Property(i => i.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(i => i.InUse)
            .IsRequired();

        // Relationships
        //builder.HasMany(b => b.Locations)
        //    .WithOne(bi => bi.LocationRow)
        //    .HasForeignKey(bi => bi.LocationRowId)
        //    .OnDelete(DeleteBehavior.Restrict);

        //builder.Navigation(l => l.Locations).AutoInclude();

        builder.HasData(LocationRowSeeder.GetSeedData());
    }
}
