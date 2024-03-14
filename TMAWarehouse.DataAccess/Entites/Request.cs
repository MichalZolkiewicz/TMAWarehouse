using System.ComponentModel.DataAnnotations.Schema;

namespace TMAWarehouse.DataAccess.Entites;

public class Request : BaseEntity
{
    public Employee Employee { get; set; }

    [ForeignKey(nameof(Employee.Name))]
    public string EmployeeName { get; set; }

    public Item Item { get; set; }    

    public int ItemId { get; set; }

    public string UnitOfMeasurement { get; set; }

    public int Quantity { get; set; }

    public double NetPrice { get; set; }

    public string Comment { get; set; }
}
