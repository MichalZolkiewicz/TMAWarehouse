using MediatR;

namespace TMAWarehouse.ApplicationServices.API.Domain.Item.DeleteItem;

public class DeleteItemRequest : IRequest<DeleteItemResponse>
{
    public int Id { get; set; }
}
