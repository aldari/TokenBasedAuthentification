namespace ParrotWingsTransfer.CqsDataModel.CqsCore
{
	public interface ICommandsFactory
	{
		void ExecuteCommand<T>(T command)
			where T : class, ICommand;
	}
}