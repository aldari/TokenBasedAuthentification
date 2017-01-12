using System;
using ParrotWingsTransfer.CqsDataModel.CqsCore;

namespace ParrotWingsTransfer.CqsDataModel.Transfer.Query
{
    public interface IGetBalanceQuery : IQuery
    {
        decimal Execute(Guid accountId);
    }
}
