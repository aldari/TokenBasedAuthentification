namespace ParrotWingsTransfer.CqsDataModel.CqsCore
{
	public interface IQueryFactory
	{
		T ResolveQuery<T>()
			where T : class, IQuery;
	}
}