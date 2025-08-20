using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;


namespace StoreApp.Dal.EntityConfigurations;
public class LocationConfiguration : EntityConfigurationBase<LocationEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LocationEntity> builder)
    {
        base.Configure(builder);
        builder.ToTable("Location");
        builder.Property(i => i.Description)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(i => i.LocationRowId)
            .IsRequired()
            .HasColumnType("int");
        builder.Property(i => i.RackNo)
            .IsRequired()
            .HasColumnType("int");
        builder.Property(i => i.StartedUsingOn)
            .IsRequired();

        // configure relationships
        //builder.HasOne(l => l.LocationRow)
        //    .WithMany(l => l.Locations)
        //    .HasForeignKey(l => l.LocationRowId)
        //    .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(l => l.LocationRow)
            .WithMany(lr => lr.Locations)
            .HasForeignKey(l => l.LocationRowId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(b => b.LocationRow).AutoInclude();

        builder.HasData(LocationSeeder.GetSeedData());
    }
}
