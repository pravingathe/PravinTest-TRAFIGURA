namespace EquityPositions.Api.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; } // PK

        public int TradeId { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string Action { get; set; } // INSERT, UPDATE, CANCEL
        public string BuySell { get; set; } // Buy, Sell
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}