using System;

namespace ParrotWingsTransfer.CqsDataModel.CqsCore
{
	public interface ICommandHandler<in TCommand> : IDisposable
		where TCommand : ICommand
	{
		void Execute(TCommand command);
	}
}