using System.ComponentModel.DataAnnotations;

namespace TMAWarehouse.DataAccess.Entites;

public class Coordinator : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Surname { get; set; }
}
