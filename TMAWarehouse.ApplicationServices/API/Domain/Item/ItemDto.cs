namespace TMAWarehouse.ApplicationServices.API.Domain.Item;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public string StorageLocation { get; set; }

}
