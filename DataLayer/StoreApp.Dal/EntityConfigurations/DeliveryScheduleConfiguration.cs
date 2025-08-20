using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Dal.DataSeeder;
using StoreApp.Dal.Entities;
using StoreApp.Dal.EntityConfigurations.Base;

namespace StoreApp.Dal.EntityConfigurations
{
    public class DeliveryScheduleConfiguration : EntityConfigurationBase<DeliveryScheduleEntity>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DeliveryScheduleEntity> builder)
        {
            base.Configure(builder);
            builder.ToTable("DeliverySchedule");
            builder.Property(b => b.BillItemId)
                .IsRequired();
             builder.Property(b => b.DeliveryDate)
                .IsRequired(); 
            builder.Property(b => b.Quantity)
                .IsRequired();

            // Relationships
            builder.HasOne(b => b.BillItem)
                .WithMany(bl => bl.DeliverySchedules)
                .HasForeignKey(b => b.BillItemId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Navigation(b => b.BillItem).AutoInclude();

            builder.HasData(DeliveryScheduleSeeder.GetSeedData());
        }
    }
}
