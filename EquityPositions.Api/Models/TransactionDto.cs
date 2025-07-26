namespace EquityPositions.Api.Models
{
    public class TransactionDto
    {
        public int TradeId { get; set; }
        public int Version { get; set; }
        public string SecurityCode { get; set; }
        public int Quantity { get; set; }
        public string Action { get; set; } // INSERT, UPDATE, CANCEL
        public string BuySell { get; set; } // Buy, Sell
    }

    public class PositionDto
    {
        public string SecurityCode { get; set; }
        public int Position { get; set; }
    }
}