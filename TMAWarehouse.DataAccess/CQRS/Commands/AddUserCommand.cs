using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands;

public class AddUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(WarehouseContext context)
    {
        await context.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}
