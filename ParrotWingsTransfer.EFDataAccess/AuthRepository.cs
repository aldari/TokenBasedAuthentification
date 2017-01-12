using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ParrotWingsTransfer.API.Models;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;

namespace ParrotWingsTransfer.EFDataAccess
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthContext _ctx;

        private readonly ApplicationUserManager _userManager;

        public AuthRepository(AuthContext authContext)
        {
            _ctx = authContext;
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new ApplicationUser
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                Fullname = userModel.UserName,
                Account = new Account { Id =  Guid.NewGuid()}
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            
            _ctx.Transactions.Add(new AccountTransaction
            {
                Amount = 500,
                TransDate = DateTime.Now,
                DebitAccount = user.Account,
                CreditAccount = _ctx.Accounts.First(x=>x.Id == AuthContext.SystemAccount)
            });
            _ctx.SaveChanges();
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return (ApplicationUser) user;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUser user, string authenticationType)
        {
            var userIdentity = await _userManager.CreateIdentityAsync(user, authenticationType);
            return userIdentity;
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}