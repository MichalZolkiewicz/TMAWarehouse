using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMAWarehouse.ApplicationServices.API.Domain.Request.AddRequest;
using TMAWarehouse.ApplicationServices.API.Domain.Request.UpdateRequest;

namespace TMAWarehouse.Controllers;

[ApiController]
[Route("/Request")]
public class RequestController : ApiControllerBase
{
    public RequestController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [Route("/AddRequest")]
    public Task<IActionResult> AddRequest([FromBody] AddRequestRequest request)
    {
        return this.HandleRequest<AddRequestRequest, AddRequestResponse>(request);
    }

    [HttpPut]
    [Route("/UpdateRequest")]
    public Task<IActionResult> UpdateRequestStatus([FromBody] UpdateRequestRequest request)
    {
        return this.HandleRequest<UpdateRequestRequest, UpdateRequestResponse>(request);
    }
        
}
