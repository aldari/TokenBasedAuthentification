using System;
using System.Data.Entity;
using System.Linq;
using ParrotWingsTransfer.CqsDataModel.Transfer.Command;
using ParrotWingsTransfer.EFDataAccess.Core;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Command
{
    public class AddTransactionCommandHandler : EfCommandHandlerBase<AddTransactionCommand, AuthContext>
    {
        public AddTransactionCommandHandler(AuthContext dbContext)
            : base(dbContext)
        {
        }

        public override void Execute(AddTransactionCommand command)
        {
            var user = DbContext.Users.Include(x => x.Account).Single(x=>x.Id == command.SourceUser);
            var destinationUser = DbContext.Users.Include(x => x.Account).Single(x => x.Id == command.DestinationUser);

            if (user == null || destinationUser == null)
                throw new ArgumentException("Wrong User");

            var sum =
                DbContext.Transactions.Where(x => x.CreditAccount.Id == user.Account.Id || x.DebitAccount.Id == user.Account.Id)
                    .Sum(x => (x.DebitAccount.Id == user.Account.Id) ? x.Amount : -x.Amount);

            if (sum - command.Amount >=0)
                DbContext.Transactions.Add(new AccountTransaction { TransDate = DateTime.Now, Amount = command.Amount, CreditAccount = user.Account, DebitAccount = destinationUser.Account });

            DbContext.SaveChanges();
        }
    }
}
