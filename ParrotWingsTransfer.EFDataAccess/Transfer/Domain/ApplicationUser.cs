using Microsoft.AspNet.Identity.EntityFramework;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Fullname { get; set; }
        public virtual Account Account { get; set; }
    }
}