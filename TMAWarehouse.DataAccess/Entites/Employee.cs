using System.ComponentModel.DataAnnotations;

namespace TMAWarehouse.DataAccess.Entites;

public class Employee : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [StringLength(100)]
    public string Surname { get; set; }

    public int RequestId { get; set; }

    public Request Request { get; set; }
}
