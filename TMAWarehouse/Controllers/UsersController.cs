using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMAWarehouse.ApplicationServices.API.Domain.User.AddUser;

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
}
