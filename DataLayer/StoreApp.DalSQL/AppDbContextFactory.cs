using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using StoreApp.Dal.Context;

namespace StoreApp.DalSQL;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=StoreAppDb;TrustServerCertificate=True;User ID=sa;Password=Letmein@123;");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}