using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess;

public class WarehouseContext : DbContext
{
    public WarehouseContext(DbContextOptions<WarehouseContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Coordinator> Coordinators { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Item> Items { get; set; }

    public DbSet<Request> Requests { get; set; }
}
