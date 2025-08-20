using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations;

public class BillItemConfiguration : EntityConfigurationBase<BillItemEntity>
{
    public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BillItemEntity> builder)
    {
        base.Configure(builder);
        builder.ToTable("BillItem");
        builder.Property(b => b.BillId)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(b => b.ItemId)
            .IsRequired()
            .HasMaxLength(10);
        builder.Property(b => b.Quantity)
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(b => b.Price)
            .IsRequired()
            .HasDefaultValue(0);
        builder.Property(b => b.Amount)
            .IsRequired()
            .HasDefaultValue(0);

        // Relationships
        builder.HasOne(b => b.Bill)
            .WithMany(b => b.BillItems)
            .HasForeignKey(b => b.BillId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        builder.HasOne(b => b.Item)
            .WithMany(i => i.BillItems)
            .HasForeignKey(b => b.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Navigation(b => b.Item).AutoInclude();
        builder.Navigation(b => b.Bill).AutoInclude();
        builder.Navigation(b => b.DeliverySchedules).AutoInclude();

        builder.HasData(BillItemSeeder.GetSeedData());
    }
}
