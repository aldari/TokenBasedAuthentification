using System;
using System.Data.Entity;
using System.Linq;
using NUnit.Framework;
using ParrotWingsTransfer.EFDataAccess;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;

namespace ParrotWingsTransfer.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            using (var context = new AuthContext("name=AngularJSAuth"))
            {
                var user = context.Users.Include(x => x.Account).First(x=>x.Fullname == "Stephen Curry");
                var destinationUser = context.Users.Include(x=>x.Account).First(x => x.Fullname == "James Harden");

                //using (var contextTransaction = context.Database.BeginTransaction())
                //{
                    context.Transactions.Add(new AccountTransaction { TransDate = DateTime.Now, Amount = 100, CreditAccount = user.Account, DebitAccount = destinationUser.Account });
                    
                    context.SaveChanges();
                    //contextTransaction.Commit();
                //}
            }
        }

        [Test]
        public void Test2()
        {
            using (var context = new AuthContext("name=AngularJSAuth"))
            {
                var user = context.Users.Include(x => x.Account).First(x => x.Fullname == "Stephen Curry");
                var destinationUser = context.Users.Include(x => x.Account).First(x => x.Fullname == "James Harden");

                
            }
        }
    }
}
