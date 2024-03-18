using MediatR;

namespace TMAWarehouse.ApplicationServices.API.Domain.Item.UpdateItemQuantity;

public class UpdateItemQuantityRequest : IRequest<UpdateItemQuantityResponse>
{
    public int Id { get; set; }
    public int ItemQuantity { get; set; }
}
