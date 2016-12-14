using System.Data.Entity;
using ParrotWingsTransfer.CqsDataModel.CqsCore;

namespace ParrotWingsTransfer.EFDataAccess.Core
{
	public abstract class EfQueryBase<TContext> : IQuery
		where TContext : DbContext
	{
		protected readonly TContext DbContext;

		protected EfQueryBase(TContext dbContext)
		{
			DbContext = dbContext;
		}
	}
}