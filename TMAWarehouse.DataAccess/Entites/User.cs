using System.ComponentModel.DataAnnotations;
using TMAWarehouse.DataAccess.Entites.Enums;

namespace TMAWarehouse.DataAccess.Entites;

public class User : BaseEntity
{
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
   
    [Required]
    [MaxLength(250)]
    public string Surname { get; set; }
    
    [Required]
    [MaxLength(250)]
    public string Login { get; set; }

    [Required]
    [MaxLength(250)]
    public string Password { get; set; }

    [EnumDataType(typeof(PositionType))]
    public PositionType PositionType { get; set; }
}
