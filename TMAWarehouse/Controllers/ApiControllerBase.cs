using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TMAWarehouse.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;

    protected ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
    {
        var response = await _mediator.Send(request);
        return this.Ok(response);
    }
}
