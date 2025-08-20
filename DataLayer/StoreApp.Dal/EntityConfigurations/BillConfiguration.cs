
using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.DataSeeder;

//using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations;

public class BillConfiguration : EntityConfigurationBase<BillEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BillEntity> builder)
    {
        base.Configure(builder);
        builder.ToTable("Bill");
        builder.Property(b => b.BillNumber)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(b => b.BillDate)   
            .IsRequired(); 
        builder.Property(b => b.PartyId)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(b => b.ItemTotal)    
            .IsRequired()
            .HasDefaultValue(0);
        builder.Property(b => b.Discount)
            .HasDefaultValue(0);
        builder.Property(b => b.NetAmount)
            .IsRequired()
            .HasDefaultValue(0);

        // Relationships
        builder.HasOne(b => b.Party)
            .WithMany(p => p.Bills)
            .HasForeignKey(b => b.PartyId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Navigation(b => b.Party).AutoInclude();
        builder.Navigation(b => b.BillItems).AutoInclude();

        builder.HasData(BillSeeder.GetSeedData());
    }
}
