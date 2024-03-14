using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMAWarehouse.DataAccess.Entites;

public class Item : BaseEntity
{
    [Required]
    [StringLength(250)]
    public string Name { get; set; }
   
    [Required]
    public string ItemGroup { get; set; }
    
    [Required]
    public string UnitOfMeasurement { get; set; }
    
    [Required]
    public int Quantity { get; set; }

    [Required]
    public double NetPrice { get; set; }

    [Required]
    [Column(TypeName = "VARCHAR")]
    [StringLength(100)]
    public string Status { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(100)]
    public string StorageLocation { get; set; }

    [Column(TypeName = "VARCHAR")]
    [StringLength(400)]
    public string ContactPerson { get; set; }

    public List<Request> Requests { get; set; }
}
