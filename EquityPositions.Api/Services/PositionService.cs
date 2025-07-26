using EquityPositions.Api.Models;
using EquityPositions.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace EquityPositions.Api.Services
{
    public class PositionService
    {
        private readonly EquityContext _context;

        public PositionService(EquityContext context)
        {
            _context = context;
        }

        public async Task<List<PositionDto>> GetPositionsAsync()
        {
            // 1. Select only latest version for each TradeId
            var latest = await _context.Transactions
                .GroupBy(t => t.TradeId)
                .Select(g => g.OrderByDescending(t => t.Version).FirstOrDefault())
                .ToListAsync();

            // 2. Ignore CANCELLED trades
            var nonCancelled = latest.Where(t => t.Action != "CANCEL");

            // 3. Compute position per security
            var positions = nonCancelled
                .GroupBy(x => x.SecurityCode)
                .Select(g => new PositionDto
                {
                    SecurityCode = g.Key,
                    Position = g.Sum(t => t.BuySell == "Buy" ? t.Quantity : -t.Quantity)
                })
                .ToList();

            return positions;
        }
    }
}