using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;

namespace ParrotWingsTransfer.EFDataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ParrotWingsTransfer.EFDataAccess.AuthContext";
        }

        protected override void Seed(AuthContext context)
        {
            var users = context.Users.ToList();
            if (!users.Any(z => z.Fullname == "James Harden"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);

                var items = new[]
                {
                    new {name = "Stephen Curry", email = "curry@gmail.com"},
                    new {name = "Karl - Anthony Towns", email = "towns@gmail.com"},
                    new {name = "James Harden", email = "harden@gmail.com"},
                    new {name = "LeBron James", email = "james@gmail.com"},
                    new {name = "Kawhi Leonard", email = "leonard@gmail.com"},
                    new {name = "Kevin Durant", email = "durant@gmail.com"},
                    new {name = "Kawhi Leonard", email = "leonard@gmail.com"},
                    new {name = "DeMarcus Cousins", email = "cousins@gmail.com"},
                    new {name = "Chris Paul", email = "paul@gmail.com"},
                    new {name = "Anthony Davis", email = "davis@gmail.com"},
                };
                foreach (var item in items)
                {
                    var user = new ApplicationUser
                    {
                        Email = item.email,
                        UserName = item.email,
                        Fullname = item.name,
                        Account = new Account {Id = Guid.NewGuid()}
                    };
                    manager.Create(user, "password");
                }
            }
        }
    }
}
