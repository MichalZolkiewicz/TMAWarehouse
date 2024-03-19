using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Error;
using TMAWarehouse.ApplicationServices.API.Domain.User;
using TMAWarehouse.ApplicationServices.API.Domain.User.DeleteUser;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Commands;
using TMAWarehouse.DataAccess.CQRS.Queries;
using TMAWarehouse.DataAccess.Entites.Enums;

namespace TMAWarehouse.ApplicationServices.API.Handlers.User;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public DeleteUserHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }
    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var adminQuery = new GetUserByIdQuery() { Id = request.AdminId };
        var admin = await _queryExecutor.Execute(adminQuery);

        if(admin.PositionType != PositionType.Admin)
        {
            return new DeleteUserResponse() 
            { 
                Error = new ErrorModel(ErrorType.Unauthorized) 
            };
        }

        var command = new DeleteUserCommand() { Id = request.UserId };
        var user = await _commandExecutor.Execute(command);
        var mapperUser = _mapper.Map<UserDto>(user);

        return new DeleteUserResponse()
        {
            Data = mapperUser
        };
    }
}
