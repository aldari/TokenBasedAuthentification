using System;

namespace ParrotWingsTransfer.EFDataAccess.Transfer.Domain
{
    public class AccountTransaction
    {
        public long Id { get; set; }
        public DateTime TransDate { get; set; }
        public decimal  Amount { get; set; }
        public virtual Account DebitAccount { get; set; }
        public virtual Account CreditAccount { get; set; }
    }
}