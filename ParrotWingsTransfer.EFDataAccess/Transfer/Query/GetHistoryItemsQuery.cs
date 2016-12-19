using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
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
            var minSqlDate = new DateTime(1753, 1, 1);
            var user = DbContext.Users.Include(x=>x.Account).Single(x=>x.Id == userId);
            if (userId == null)
                throw new ArgumentException("Wrong Id");
            return DbContext.Database.SqlQuery<HistoryItemDto>(
                         Utils.LoadSqlStatement("ParrotWingsTransfer.EFDataAccess", "Query.sql"),
                         new SqlParameter("account_id", user.Account.Id),
                         new SqlParameter("username", username ?? ""),
                         new SqlParameter("amountmax", amountMax ?? decimal.MaxValue),
                         new SqlParameter("amountmin", amountMin ?? decimal.MinValue),
                         new SqlParameter("datemin", dateMin ?? minSqlDate),
                         new SqlParameter("datemax", dateMax ?? DateTime.MaxValue)
                         ).ToList();
        }
    }
}
