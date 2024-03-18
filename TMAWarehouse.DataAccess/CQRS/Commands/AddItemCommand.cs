using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands;

public class AddItemCommand : CommandBase<Item, Item>
{
    public override async Task<Item> Execute(WarehouseContext context)
    {
        await context.Items.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
