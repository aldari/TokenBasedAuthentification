using System;
using System.Linq;
using NUnit.Framework;
using ParrotWingsTransfer.EFDataAccess;
using ParrotWingsTransfer.EFDataAccess.Transfer.Query;

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
                AccountId = context.Users.Single(x=>x.Fullname== "Eldar Ismagilov").Account.Id,
                Username = null,
                AmountMax = null,
                AmountMin = null,
                DateMax = new DateTime(2016, 12, 8),
                DateMin = new DateTime(2016, 12, 8)
            };
            var query = new GetHistoryItemsQuery(context);
            var items2 = query.Execute(filter.AccountId.ToString(), filter.Username, filter.AmountMax, filter.AmountMin, filter.DateMax,
                filter.DateMin);

            foreach (var item in items2)
                Console.WriteLine($"{item.Id} {item.Dateaccount} {item.Amount} {item.Corr}");
        }
    }

    public class Filter
    {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public decimal? AmountMax { get; set; }
        public decimal? AmountMin { get; set; }
        public DateTime? DateMin { get; set; }
        public DateTime? DateMax { get; set; }
    }
}