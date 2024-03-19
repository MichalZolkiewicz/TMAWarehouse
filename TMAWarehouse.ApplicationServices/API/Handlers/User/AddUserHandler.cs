using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.User;
using TMAWarehouse.ApplicationServices.API.Domain.User.AddUser;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;

namespace TMAWarehouse.ApplicationServices.API.Handlers.User;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddUserHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<DataAccess.Entites.User>(request);
        var command = new AddUserCommand() { Parameter = user };
        var userAddedToDb = await _commandExecutor.Execute(command);

        return new AddUserResponse()
        {
            Data = _mapper.Map<UserDto>(userAddedToDb)
        };
    }
}
