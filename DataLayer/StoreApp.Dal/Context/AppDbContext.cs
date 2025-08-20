using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.Entities;

namespace StoreApp.Dal.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            
        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<UnitEntity> Units { get; set; }
    public DbSet<ItemEntity> Items { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<LocationRowEntity> LocationRow { get; set; }
    public DbSet<PartyEntity> Party { get; set; }
    public DbSet<BillEntity> Bill { get; set; }
    public DbSet<BillItemEntity> BillLine { get; set; }
    public DbSet<DeliveryScheduleEntity> BillSchedule { get; set; }
}