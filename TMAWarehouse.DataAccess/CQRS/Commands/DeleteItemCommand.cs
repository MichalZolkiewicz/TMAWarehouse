using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands;

public class DeleteItemCommand : CommandBase<Item, Item>
{
    public int Id { get; set; }
    public override async Task<Item> Execute(WarehouseContext context)
    {
        var item = await context.Items.FirstOrDefaultAsync(x => x.Id == Id);
        context.Items.Remove(item);
        await context.SaveChangesAsync();
        return item;
    }
}
