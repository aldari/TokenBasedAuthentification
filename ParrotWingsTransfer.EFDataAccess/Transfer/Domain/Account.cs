using System;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}