using System;
using System.Data.Entity;
using ParrotWingsTransfer.CqsDataModel.CqsCore;

namespace ParrotWingsTransfer.EFDataAccess.Core
{
	public abstract class EfCommandHandlerBase<TCommand, TContext> : ICommandHandler<TCommand>, IDisposable
		where TCommand : ICommand
		where TContext : DbContext
	{
		protected readonly TContext DbContext;

		protected EfCommandHandlerBase(TContext dbContext)
		{
			DbContext = dbContext;
		}

		public abstract void Execute(TCommand command);

		public void Dispose()
		{
			DbContext.Dispose();
		}
	}
}