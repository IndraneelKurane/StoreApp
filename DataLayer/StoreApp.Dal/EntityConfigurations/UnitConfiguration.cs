using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations;

public class UnitConfiguration : EntityConfigurationBase<UnitEntity>
{
    public override void Configure(EntityTypeBuilder<UnitEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("Unit");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(UnitSeeder.GetSeedData());
    }
}
