using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Request;
using TMAWarehouse.ApplicationServices.API.Domain.Request.UpdateRequest;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Request;

public class UpdateRequestHandler : IRequestHandler<UpdateRequestRequest, UpdateRequestResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateRequestHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateRequestResponse> Handle(UpdateRequestRequest request, CancellationToken cancellationToken)
    {
        var _request = _mapper.Map<DataAccess.Entites.Request>(request);
        var command = new UpdateRequestStatusCommand() { Parameter = _request };
        var updatedRequest = await _commandExecutor.Execute(command);

        return new UpdateRequestResponse()
        {
            Data = _mapper.Map<RequestDto>(updatedRequest)
        };
    }
}
