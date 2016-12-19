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

        public List<HistoryItemDto> Post(FilterModel model)
        {
            return _getHistoryItemsQuery.Execute(User.Identity.GetUserId(), model.Username, model.AmountMax, model.AmountMin,
                model.DateMin, model.DateMax);
        }
    }

    public class FilterModel
    {
        public string Username { get; set; }
        public decimal? AmountMax { get; set; }
        public decimal? AmountMin { get; set; }
        public DateTime? DateMax { get; set; }
        public DateTime? DateMin { get; set; }
    }
}
