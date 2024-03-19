using MediatR;

namespace TMAWarehouse.ApplicationServices.API.Domain.Item.AddItem;

public class AddItemRequest : IRequest<AddItemResponse>
{
    public string Name { get; set; }
    public string ItemGroup { get; set; }
    public string UnitOfMeasurement { get; set; }
    public int Quantity { get; set; }
    public double NetPrice { get; set; }
    public string Status { get; set; }
    public string StorageLocation { get; set; }
    public string ContactPerson { get; set; }

    public int CoordinatorId {  get; set; }     
}
