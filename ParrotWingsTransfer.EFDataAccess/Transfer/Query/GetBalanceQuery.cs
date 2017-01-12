using System;
using System.Linq;
using System.Data.SqlClient;
using ParrotWingsTransfer.API;
using ParrotWingsTransfer.CqsDataModel.Transfer.Query;
using ParrotWingsTransfer.EFDataAccess.Core;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Query
{
    public class GetBalanceQuery : EfQueryBase<AuthContext>, IGetBalanceQuery
    {
        public GetBalanceQuery(AuthContext context)
            : base(context)
        {
        }

        public decimal Execute(Guid accountId)
        {
            //var user = DbContext.Users.Include(x => x.Account).Single(x => x.Id == userId);
            if (accountId == null)
                throw new ArgumentException("Wrong Id");
            return DbContext.Database.SqlQuery<decimal>(
                         Utils.LoadSqlStatement("ParrotWingsTransfer.EFDataAccess", "BalanceQuery.sql"),
                         new SqlParameter("account_id", accountId)
                         ).Single();

        }
    }
}
