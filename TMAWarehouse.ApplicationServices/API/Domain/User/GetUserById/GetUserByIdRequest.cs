using MediatR;

namespace TMAWarehouse.ApplicationServices.API.Domain.User.GetUserById;

public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
{
    public int UserId { get; set; }
}
