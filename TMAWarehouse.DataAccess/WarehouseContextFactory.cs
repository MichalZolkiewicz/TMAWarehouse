using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TMAWarehouse.DataAccess;

public class WarehouseContextFactory : IDesignTimeDbContextFactory<WarehouseContext>
{
    public WarehouseContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
        optionsBuilder.UseSqlServer("Data Source=LAPTOP-AJM90S2R;Initial Catalog=WarehouseProgram;Integrated Security=True;Encrypt=False");
        return new WarehouseContext(optionsBuilder.Options);
    }
}
