using System;
using ParrotWingsTransfer.CqsDataModel.CqsCore;

namespace ParrotWingsTransfer.CqsDataModel.Transfer.Command
{
    public struct AddTransactionCommand: ICommand
    {
        public string SourceUser { get; }
        public string DestinationUser { get; }
        public decimal Amount { get; }

        public AddTransactionCommand(string sourceUser, string destinationUser, decimal amount)
        {
            SourceUser = sourceUser;
            DestinationUser = destinationUser;
            Amount = amount;
        }
    }
}
