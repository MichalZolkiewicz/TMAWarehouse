using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess;

public class WarehouseContext : DbContext
{
    public WarehouseContext(DbContextOptions<WarehouseContext> options) 
        : base(options)
    {
        
    }
    
    public DbSet<Item> Items { get; set; }

    public DbSet<Request> Requests { get; set; }

    public DbSet<User> Users { get; set; }
}
