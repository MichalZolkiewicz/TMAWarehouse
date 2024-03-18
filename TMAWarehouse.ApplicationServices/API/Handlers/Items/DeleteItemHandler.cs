using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.DeleteItem;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Items;

public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public DeleteItemHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }
    public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        var command = new DeleteItemCommand()
        {
            Id = request.Id
        };

        var item = await _commandExecutor.Execute(command);
        var mappedItem = _mapper.Map<ItemDto>(item);

        var response = new DeleteItemResponse()
        {
            Data = mappedItem
        };
        return response;
    }
}
