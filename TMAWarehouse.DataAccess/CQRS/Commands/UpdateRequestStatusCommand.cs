using Microsoft.EntityFrameworkCore;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.DataAccess.CQRS.Commands
{
    public class UpdateRequestStatusCommand : CommandBase<Request, Request>
    {
        public override async Task<Request> Execute(WarehouseContext context)
        {
            var request = await context.Requests.FirstOrDefaultAsync(x => x.Id == this.Parameter.Id);
            var item = await context.Items.FirstOrDefaultAsync(x => x.Id == request.ItemId);
            if (request != null && item != null && item.Quantity > this.Parameter.Quantity) 
            {
                request.Status = this.Parameter.Status;
                item.Quantity = item.Quantity - request.Quantity;
            }
            
            await context.SaveChangesAsync();
            return request;
        }
    }
}
