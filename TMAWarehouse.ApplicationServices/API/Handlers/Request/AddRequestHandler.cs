using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Request;
using TMAWarehouse.ApplicationServices.API.Domain.Request.AddRequest;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Request;

public class AddRequestHandler : IRequestHandler<AddRequestRequest, AddRequestResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public AddRequestHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }
    public async Task<AddRequestResponse> Handle(AddRequestRequest request, CancellationToken cancellationToken)
    {               
        var newRequest = _mapper.Map<DataAccess.Entites.Request>(request);
        var command = new AddRequestCommand() { Parameter = newRequest };
        var requestAddedToDb = await _commandExecutor.Execute(command);

        return new AddRequestResponse()
        {
            Data = _mapper.Map<RequestDto>(requestAddedToDb)
        };
    }
}
