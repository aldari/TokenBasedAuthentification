using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ParrotWingsTransfer.CqsDataModel.Transfer.Dto;
using ParrotWingsTransfer.CqsDataModel.Transfer.Query;

namespace ParrotWingsTransfer.API.Controllers
{
    public class HistoryController : ApiController
    {
        private readonly IGetHistoryItemsQuery _getHistoryItemsQuery;

        public HistoryController(IGetHistoryItemsQuery getHistoryItemsQuery)
        {
            _getHistoryItemsQuery = getHistoryItemsQuery;
        }

        public List<HistoryItemDto> Get(decimal? amountmax, decimal? amountmin,
            DateTime? datemax, DateTime? datemin, string filterByUsername = null)
        {
            return _getHistoryItemsQuery.Execute(User.Identity.GetUserId(), filterByUsername,
                amountmin, amountmin, datemax, datemin);
        }
    }
}
