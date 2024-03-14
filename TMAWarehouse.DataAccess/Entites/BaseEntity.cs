using System.ComponentModel.DataAnnotations;

namespace TMAWarehouse.DataAccess.Entites;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
