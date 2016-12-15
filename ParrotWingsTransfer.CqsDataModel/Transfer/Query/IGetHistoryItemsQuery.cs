using System;
using System.Collections.Generic;
using ParrotWingsTransfer.CqsDataModel.CqsCore;
using ParrotWingsTransfer.CqsDataModel.Transfer.Dto;

namespace ParrotWingsTransfer.CqsDataModel.Transfer.Query
{
    public interface IGetHistoryItemsQuery : IQuery
    {
        List<HistoryItemDto> Execute(string accountId, string username, decimal? amountMax, decimal? amountMin, DateTime? dateMin, DateTime? dateMax);
    }
}
