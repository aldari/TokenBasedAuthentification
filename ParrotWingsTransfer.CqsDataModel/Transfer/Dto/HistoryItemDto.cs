using System;

namespace ParrotWingsTransfer.CqsDataModel.Transfer.Dto
{
    public class HistoryItemDto
    {
        public long Id { get; set; }
        public DateTime Dateaccount { get; set; }
        public decimal Amount { get; set; }
        public string Correspondent { get; set; }
    }
}
