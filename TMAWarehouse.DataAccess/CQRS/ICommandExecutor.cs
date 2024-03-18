using TMAWarehouse.DataAccess.CQRS.Commands;

namespace TMAWarehouse.DataAccess.CQRS;

public interface ICommandExecutor
{
    Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command);
}
