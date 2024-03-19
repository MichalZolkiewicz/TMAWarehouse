using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Error;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.AddItem;
using TMAWarehouse.ApplicationServices.API.Domain.Item.DeleteItem;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;
using TMAWarehouse.DataAccess.CQRS.Queries;
using TMAWarehouse.DataAccess.Entites;
using TMAWarehouse.DataAccess.Entites.Enums;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Items;

internal class AddItemHandler : IRequestHandler<AddItemRequest, AddItemResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public AddItemHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }
    public async Task<AddItemResponse> Handle(AddItemRequest request, CancellationToken cancellationToken)
    {
        var coordinatorQuery = new GetUserByIdQuery { Id = request.CoordinatorId };
        var coordinator = await _queryExecutor.Execute(coordinatorQuery);

        if (coordinator.PositionType != PositionType.Coordinator)
        {
            return new AddItemResponse()
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }

        var item = _mapper.Map<Item>(request);
        var command = new AddItemCommand() { Parameter = item };
        var itemAddedToDb = await _commandExecutor.Execute(command);

        return new AddItemResponse()
        {
            Data = _mapper.Map<ItemDto>(itemAddedToDb)
        };
    }
}
