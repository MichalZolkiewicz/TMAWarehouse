using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMAWarehouse.ApplicationServices.API.Domain.Item.GetAllItems;

namespace TMAWarehouse.Controllers;

[ApiController]
[Route("/Items")]
public class ItemsController : ApiControllerBase
{
    public ItemsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    public Task<IActionResult> GetAllItems([FromQuery] GetAllItemsRequest request)
    {
        return this.HandleRequest<GetAllItemsRequest, GetAllItemsResponse>(request);
    }
}
