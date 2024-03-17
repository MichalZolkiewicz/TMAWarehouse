using TMAWarehouse.DataAccess.CQRS.Queries;

namespace TMAWarehouse.DataAccess.CQRS;

public class QueryExecutor : IQueryExecutor
{
    private readonly WarehouseContext _context;

    public QueryExecutor(WarehouseContext context)
    {
        _context = context;
    }
    public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
    {
        return query.Execute(_context);
    }
}
