using MediatR;
using TMAWarehouse.DataAccess.Entites.Enums;

namespace TMAWarehouse.ApplicationServices.API.Domain.User.AddUser;

public class AddUserRequest : IRequest<AddUserResponse>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public PositionType PositionType { get; set; }
}
