using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations;

public class PartyConfiguration : EntityConfigurationBase<PartyEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PartyEntity> builder)
    {
        base.Configure(builder);
        builder.ToTable("Party");
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(p => p.Address)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(p => p.PhoneNumber)
            .IsRequired()
            .HasMaxLength(15);
        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(100);


        builder.HasData(PartySeeder.GetSeedData());
    }
}
