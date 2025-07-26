using Microsoft.AspNetCore.Mvc;
using EquityPositions.Api.Data;
using EquityPositions.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EquityPositions.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly EquityContext _context;

        public TransactionsController(EquityContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransaction(TransactionDto dto)
        {
            // Validate action
            if (!new[] { "INSERT", "UPDATE", "CANCEL" }.Contains(dto.Action))
                return BadRequest("Invalid action.");
            if (!new[] { "Buy", "Sell" }.Contains(dto.BuySell))
                return BadRequest("Invalid BuySell value.");

            // Prevent duplicate
            var exists = await _context.Transactions.AnyAsync(t => t.TradeId == dto.TradeId && t.Version == dto.Version);
            if (exists) return Conflict("This version already exists for this trade.");

            // For CANCEL, ignore all fields except TradeId/Version/Action (but store others for audit/tracking)
            var tx = new Transaction
            {
                TradeId = dto.TradeId,
                Version = dto.Version,
                SecurityCode = dto.SecurityCode,
                Quantity = dto.Quantity,
                Action = dto.Action,
                BuySell = dto.BuySell
            };

            _context.Transactions.Add(tx);
            await _context.SaveChangesAsync();
            return Ok(tx);
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaction>>> GetAll()
        {
            var txs = await _context.Transactions.OrderBy(t => t.TransactionId).ToListAsync();
            return Ok(txs);
        }
    }
}