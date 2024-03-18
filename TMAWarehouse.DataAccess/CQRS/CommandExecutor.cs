using TMAWarehouse.DataAccess.CQRS.Commands;

namespace TMAWarehouse.DataAccess.CQRS;

public class CommandExecutor : ICommandExecutor
{
    private readonly WarehouseContext _context;

    public CommandExecutor(WarehouseContext context)
    {
        _context = context;
    }

    public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
    {
        return command.Execute(_context);
    }
}
