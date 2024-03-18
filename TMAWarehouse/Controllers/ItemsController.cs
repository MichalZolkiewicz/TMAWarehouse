using MediatR;
using Microsoft.AspNetCore.Mvc;
using TMAWarehouse.ApplicationServices.API.Domain.Item.AddItem;
using TMAWarehouse.ApplicationServices.API.Domain.Item.DeleteItem;
using TMAWarehouse.ApplicationServices.API.Domain.Item.GetAllItems;
using TMAWarehouse.ApplicationServices.API.Domain.Item.UpdateItemQuantity;

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

    [HttpPut]
    [Route("/QuantityUpdate")]
    public Task<IActionResult> UpdateItemQuantity([FromBody] UpdateItemQuantityRequest request) 
    {
        return this.HandleRequest<UpdateItemQuantityRequest, UpdateItemQuantityResponse>(request);
    }

    [HttpPost]
    [Route("/AddItem")]
    public Task<IActionResult> AddItem([FromBody] AddItemRequest request)
    {
        return this.HandleRequest<AddItemRequest, AddItemResponse>(request);
    }

    [HttpDelete]
    [Route("/DeleteItem/{itemId}")]
    public Task<IActionResult> DeleteItem([FromRoute] int itemId)
    {
        var request = new DeleteItemRequest
        {
            Id = itemId
        };

        return this.HandleRequest<DeleteItemRequest, DeleteItemResponse>(request);
    }
}
