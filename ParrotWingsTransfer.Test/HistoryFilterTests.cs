using System;
using System.Data.SqlClient;
using System.Linq;
using NUnit.Framework;
using ParrotWingsTransfer.API;
using ParrotWingsTransfer.EFDataAccess;

namespace ParrotWingsTransfer.Test
{
    [TestFixture]
    public class HistoryFilterTests
    {
        [Test]
        public void Test1()
        {
            var context = new AuthContext();

            var filter = new Filter
            {
                AccountId = 4,
                Username = null,
                AmountMax = null,
                AmountMin = null,
                DateMax = new DateTime(2016, 12, 8),
                DateMin = new DateTime(2016, 12, 8)
            };
            var items2 = context.Database.SqlQuery<QueryResult>(
                         Utils.LoadSqlStatement("OwinApp.Web", "Query.sql"),
                         new SqlParameter("account_id", filter.AccountId),
                         new SqlParameter("username", filter.Username ?? ""),
                         new SqlParameter("amountmax", filter.AmountMax ?? decimal.MaxValue),
                         new SqlParameter("amountmin", filter.AmountMin ?? decimal.MinValue),
                         new SqlParameter("datemin", filter.DateMin ?? DateTime.MinValue),
                         new SqlParameter("datemax", filter.DateMax ?? DateTime.MaxValue)
                         )
                         .ToList();

            foreach (var item in items2)
            {
                Console.WriteLine($"{item.Id} {item.Dateaccount} {item.Amount} {item.Corr}");
            }
        }
    }

    public class Filter
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public decimal? AmountMax { get; set; }
        public decimal? AmountMin { get; set; }
        public DateTime? DateMin { get; set; }
        public DateTime? DateMax { get; set; }
    }

    public class QueryResult
    {
        public int Id { get; set; }
        public DateTime Dateaccount { get; set; }
        public decimal Amount { get; set; }
        public string Corr { get; set; }
    }
}