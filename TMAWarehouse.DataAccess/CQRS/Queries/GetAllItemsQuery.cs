using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Queries;

public class GetAllItemsQuery : QueryBase<List<Item>>
{
    public override Task<List<Item>> Execute(WarehouseContext context)
    {
        return context.Items.ToListAsync();
    }
}
