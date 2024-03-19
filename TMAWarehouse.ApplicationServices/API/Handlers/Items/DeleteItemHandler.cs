using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Error;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.DeleteItem;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;
using TMAWarehouse.DataAccess.CQRS.Queries;
using TMAWarehouse.DataAccess.Entites.Enums;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Items;

public class DeleteItemHandler : IRequestHandler<DeleteItemRequest, DeleteItemResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public DeleteItemHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }
    public async Task<DeleteItemResponse> Handle(DeleteItemRequest request, CancellationToken cancellationToken)
    {
        var coordinatorQuery = new GetUserByIdQuery { Id = request.CoordinatorId };
        var coordinator = await _queryExecutor.Execute(coordinatorQuery);

        if (coordinator.PositionType != PositionType.Coordinator)
        {
            return new DeleteItemResponse()
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }
        
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
