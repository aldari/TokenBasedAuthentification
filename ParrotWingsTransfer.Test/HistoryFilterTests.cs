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
            Guid AccountId = context.Users.Single(x => x.Fullname == "Eldar Ismagilov").Account.Id;
            string Username = null;
            decimal? AmountMax = null;
            decimal? AmountMin = null;
            DateTime? DateMax = null;
            DateTime? DateMin = null;

            

            var query = new GetHistoryItemsQuery(context);
            var items2 = query.Execute(AccountId.ToString(), Username, AmountMax, AmountMin, DateMax, DateMin);

            foreach (var item in items2)
                Console.WriteLine($"{item.Id} {item.Dateaccount} {item.Amount} {item.Correspondent}");
        }
    }
}