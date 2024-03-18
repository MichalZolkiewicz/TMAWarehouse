using MediatR;
namespace TMAWarehouse.ApplicationServices.API.Domain.Request.AddRequest;

public class AddRequestRequest : IRequest<AddRequestResponse>
{
    public string UserName { get; set; }
    public int ItemId { get; set; }
    public string UnitOfMeasurement { get; set; }
    public int Quantity { get; set; }
    public double NetPrice { get; set; }
    public string Comment { get; set; }
}
