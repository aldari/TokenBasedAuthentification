using System.Data.Entity;
using System.Linq;
using ParrotWingsTransfer.EFDataAccess.Transfer.Domain;

namespace ParrotWingsTransfer.EFDataAccess
{
    public class ContextDbInitializer : CreateDatabaseIfNotExists<AuthContext>
    {
        protected override void Seed(AuthContext context)
        {
            base.Seed(context);
            
            if (!context.Accounts.Any(z => z.Id == AuthContext.SystemAccount))
            {
                context.Accounts.Add(new Account { Id = AuthContext.SystemAccount });
                context.SaveChanges();
            }
        }
    }
}
