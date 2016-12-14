using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;

namespace ParrotWingsTransfer.EFDataAccess
{
    public class AuthContext : IdentityDbContext<ApplicationUser>
    {
        public AuthContext()
            : base("name=AngularJSAuth")
        {
        }

        public AuthContext(string connectionString= "name=AngularJSAuth")
            : base(connectionString)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountTransaction> Transactions { get; set; }

        public static readonly Guid SystemAccount = Guid.Parse("e0fcb23b-626d-4492-a2f3-5ad29e88cf91");

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasOptional(s => s.ApplicationUser)
                .WithRequired(ad => ad.Account);
        }
    }
}