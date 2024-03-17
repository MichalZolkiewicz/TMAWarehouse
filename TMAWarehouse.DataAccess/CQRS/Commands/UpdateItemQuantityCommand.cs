using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands;

public class UpdateItemQuantityCommand : CommandBase<Item, Item>
{
    public override async Task<Item> Execute(WarehouseContext context)
    {
        var item = await context.Items.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
        if(item != null) 
        {
            item.Quantity = this.Parameter.Quantity;
        }
        else
        {
            return default;
        }
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
