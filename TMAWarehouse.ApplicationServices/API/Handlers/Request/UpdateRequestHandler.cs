using AutoMapper;
using Azure;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Error;
using TMAWarehouse.ApplicationServices.API.Domain.Request;
using TMAWarehouse.ApplicationServices.API.Domain.Request.UpdateRequest;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;
using TMAWarehouse.DataAccess.CQRS.Queries;
using TMAWarehouse.DataAccess.Entites.Enums;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Request;

public class UpdateRequestHandler : IRequestHandler<UpdateRequestRequest, UpdateRequestResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public UpdateRequestHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<UpdateRequestResponse> Handle(UpdateRequestRequest request, CancellationToken cancellationToken)
    {
        var queryForUser = new GetUserByIdQuery() { Id = request.UserId };
        var user = await _queryExecutor.Execute(queryForUser);

        if (user.PositionType != PositionType.Coordinator)
        {
            return new UpdateRequestResponse()
            {
                Error = new ErrorModel(ErrorType.Unauthorized)
            };
        }
        var _request = _mapper.Map<DataAccess.Entites.Request>(request);
        var command = new UpdateRequestStatusCommand() { Parameter = _request };
        var updatedRequest = await _commandExecutor.Execute(command);

        return new UpdateRequestResponse()
        {
            Data = _mapper.Map<RequestDto>(updatedRequest)
        };
    }
}
