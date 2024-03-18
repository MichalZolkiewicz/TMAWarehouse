using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands;

public class AddRequestCommand : CommandBase<Request, Request>
{
    public override async Task<Request> Execute(WarehouseContext context)
    {
        var user = context.Users.FirstOrDefault(x => x.Name == this.Parameter.UserName);
        var item = context.Items.FirstOrDefault(x => x.Id == this.Parameter.ItemId);

        var request = new Request()
        {
            Id = this.Parameter.Id,
            User = user,
            UserName = user.Name,
            ItemId = item.Id,
            Item = item,
            UnitOfMeasurement = this.Parameter.UnitOfMeasurement,
            Quantity = this.Parameter.Quantity,
            NetPrice = this.Parameter.NetPrice,
            Comment = this.Parameter.Comment
        };

        await context.Requests.AddAsync(request);
        await context.SaveChangesAsync();
        return request;
    }
}
