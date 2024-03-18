using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Migrations;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.UpdateItemQuantity;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Items;

public class UpdateItemQuantityHandler : IRequestHandler<UpdateItemQuantityRequest, UpdateItemQuantityResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateItemQuantityHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }
    public async Task<UpdateItemQuantityResponse> Handle(UpdateItemQuantityRequest request, CancellationToken cancellationToken)
    {
        var candidate = _mapper.Map<Item>(request);
        var command = new UpdateItemQuantityCommand() { Parameter = candidate };
        var updateCandidate = await _commandExecutor.Execute(command);
        return new UpdateItemQuantityResponse
        {
            Data = _mapper.Map<ItemDto>(updateCandidate)
        };
    }
}
