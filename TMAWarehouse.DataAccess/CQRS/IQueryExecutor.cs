using TMAWarehouse.DataAccess.CQRS.Queries;

namespace TMAWarehouse.DataAccess.CQRS;

public interface IQueryExecutor
{
    Task<TResult> Execute<TResult>(QueryBase<TResult> query);
}
