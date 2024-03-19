using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Queries;

public class GetUserByIdQuery : QueryBase<User>
{
    public int Id { get; set; }
    public override async Task<User> Execute(WarehouseContext context)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
        return user;
    }
}
