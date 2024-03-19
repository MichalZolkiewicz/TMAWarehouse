using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands;

public class DeleteUserCommand : CommandBase<User, User>
{
    public int Id { get; set; }

    public override async Task<User> Execute(WarehouseContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == Id);
        context.Users.Remove(user);
        context.SaveChanges();
        return user;
    }
}
