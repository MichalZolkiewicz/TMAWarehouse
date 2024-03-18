using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.AddItem;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;
using TMAWarehouse.DataAccess.Entites;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Items;

internal class AddItemHandler : IRequestHandler<AddItemRequest, AddItemResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddItemHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }
    public async Task<AddItemResponse> Handle(AddItemRequest request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        var command = new AddItemCommand() { Parameter = item };
        var itemAddedToDb = await _commandExecutor.Execute(command);

        return new AddItemResponse()
        {
            Data = _mapper.Map<ItemDto>(itemAddedToDb)
        };
    }
}
