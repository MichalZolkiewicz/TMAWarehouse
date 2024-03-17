using AutoMapper;
using MediatR;
using TMAWarehouse.ApplicationServices.API.Domain.Item;
using TMAWarehouse.ApplicationServices.API.Domain.Item.GetAllItems;
using TMAWarehouse.DataAccess.CQRS;
using TMAWarehouse.DataAccess.CQRS.Queries;

namespace TMAWarehouse.ApplicationServices.API.Handlers.Items;

public class GetAllItemsHandler : IRequestHandler<GetAllItemsRequest, GetAllItemsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetAllItemsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetAllItemsResponse> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetAllItemsQuery();
        var items = await _queryExecutor.Execute(query);
        var mappedItems = _mapper.Map<List<ItemDto>>(items);
        var response = new GetAllItemsResponse()
        {
            Data = mappedItems
        };
        return response;
    }
}
