using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.User;
using TMAWarehouse.ApplicationServices.API.Domain.User.GetUserById;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Queries;

namespace TMAWarehouse.ApplicationServices.API.Handlers.User;

public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetUserByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }
    public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery()
        {
            Id = request.UserId
        };

        var user = await _queryExecutor.Execute(query);

        var mappedCandidate = _mapper.Map<UserDto>(user);

        var response = new GetUserByIdResponse()
        {
            Data = mappedCandidate
        };
        return response;
    }
}
