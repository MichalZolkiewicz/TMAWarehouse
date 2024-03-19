using MediatR;

namespace TMAWarehouse.ApplicationServices.API.Domain.User.DeleteUser;

public class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public int UserId { get; set; }
    public int AdminId { get; set; }
}
