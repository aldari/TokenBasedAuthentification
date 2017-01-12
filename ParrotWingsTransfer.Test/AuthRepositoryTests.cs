using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ParrotWingsTransfer.API.Models;
using ParrotWingsTransfer.CqsDataModel.Transfer.Command;
using ParrotWingsTransfer.EFDataAccess;
using ParrotWingsTransfer.EFDataAccess.Transfer.Command;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;
using ParrotWingsTransfer.EFDataAccess.Transfer.Query;

namespace ParrotWingsTransfer.Test
{
    [TestFixture]
    public class BalanceCheckIntegrationTests
    {
        private AuthContext _context;
        private readonly string cs = "name=ParrotWingsTransferTest";
        private AuthRepository _repo;

        [SetUp]
        public void SetUp()
        {
            _context = new AuthContext(cs);
            _repo = new AuthRepository(_context);

            _context.Transactions.RemoveRange(_context.Transactions.ToList());
            _context.Accounts.RemoveRange(_context.Accounts.ToList());
            foreach (var user in _context.Users.ToList())
                _context.Users.Remove(user);
            _context.SaveChanges();

            _context.Accounts.Add(new Account { Id = AuthContext.SystemAccount });
            _context.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task RegisterUser_NewCreatedUser_InitialBallanceIs500()
        {
            var userModel = new UserModel
            {
                Email = "eldar@gmail.com",
                Password = "123456",
                ConfirmPassword = "123456",
                UserName = "Eldar"
            };

           
            await _repo.RegisterUser(userModel);
            var query = new GetBalanceQuery(_context);
            var user = _context.Users.Include(x => x.Account).Single(x => x.Email == "eldar@gmail.com");
            _context.SaveChanges();
            var accountId = user.Account.Id;
            var balance = query.Execute(accountId);


            Assert.AreEqual(500, balance);
        }

        [Test]
        public async Task Transfer_UserSent20_BallanceDecreaseBy20()
        {
            var userModel = new UserModel
            {
                Email = "eldar@gmail.com",
                Password = "123456",
                ConfirmPassword = "123456",
                UserName = "Eldar"
            };
            await _repo.RegisterUser(userModel);
            var user1 = _context.Users.Include(x => x.Account).Single(x => x.Email == "eldar@gmail.com");

            var userModel2 = new UserModel
            {
                Email = "michele@gmail.com",
                Password = "123456",
                ConfirmPassword = "123456",
                UserName = "Michele"
            };
            await _repo.RegisterUser(userModel2);
            var user2 = _context.Users.Include(x => x.Account).Single(x => x.Email == "michele@gmail.com");
            _context.SaveChanges();


            var cmd = new AddTransactionCommandHandler(_context);
            cmd.Execute(new AddTransactionCommand(user1.Id, user2.Id, 20));
            var balance1 = new GetBalanceQuery(_context).Execute(user1.Account.Id);
            var balance2 = new GetBalanceQuery(_context).Execute(user2.Account.Id);

            Assert.AreEqual(480, balance1);
            Assert.AreEqual(520, balance2);
        }
    }
}
