using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMAWarehouse.ApplicationServices.API.Domain.User.AddUser;
using TMAWarehouse.ApplicationServices.API.Domain.User.DeleteUser;
using TMAWarehouse.ApplicationServices.API.Domain.User.GetUserById;

namespace TMAWarehouse.Controllers;

[ApiController]
[Route("/Users")]
public class UsersController : ApiControllerBase
{
    public UsersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("/AddUser")]
    public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
    {
        return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
    }

    [HttpGet]
    [Route("/GetUser")]
    public Task<IActionResult> GetUserById([FromQuery] int userId)
    {
        var request = new GetUserByIdRequest()
        {
            UserId = userId
        };
        return this.HandleRequest<GetUserByIdRequest, GetUserByIdResponse>(request);
    }

    [HttpDelete]
    [Route("/DeleteUser")]
    public Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
    {
        return this.HandleRequest<DeleteUserRequest, DeleteUserResponse>(request);
    }
}

