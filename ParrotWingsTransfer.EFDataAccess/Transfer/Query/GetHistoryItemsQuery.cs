using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using ParrotWingsTransfer.API;
using ParrotWingsTransfer.CqsDataModel.Transfer.Dto;
using ParrotWingsTransfer.CqsDataModel.Transfer.Query;
using ParrotWingsTransfer.EFDataAccess.Core;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Query
{
    public class GetHistoryItemsQuery : EfQueryBase<AuthContext>, IGetHistoryItemsQuery
    {
        public GetHistoryItemsQuery(AuthContext context)
            : base(context)
        {
        }

        public List<HistoryItemDto> Execute(string userId, string username, decimal? amountMax, decimal? amountMin, DateTime? dateMin, DateTime? dateMax)
        {
            var accountOwner =  DbContext.Users.Find(userId);
            if (accountOwner == null)
                return null;
            return DbContext.Database.SqlQuery<HistoryItemDto>(
                         Utils.LoadSqlStatement("ParrotWingsTransfer.EFDataAccess", "Query.sql"),
                         new SqlParameter("account_id", accountOwner.Account.Id),
                         new SqlParameter("username", username ?? ""),
                         new SqlParameter("amountmax", amountMax ?? decimal.MaxValue),
                         new SqlParameter("amountmin", amountMin ?? decimal.MinValue),
                         new SqlParameter("datemin", dateMin ?? new DateTime(1753, 1, 1)),
                         new SqlParameter("datemax", dateMax ?? DateTime.MaxValue)
                         ).ToList();
        }
    }
}
