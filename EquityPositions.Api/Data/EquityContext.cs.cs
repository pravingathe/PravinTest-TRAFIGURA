using EquityPositions.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EquityPositions.Api.Data
{
    public class EquityContext : DbContext
    {
        public EquityContext(DbContextOptions<EquityContext> options) : base(options) { }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasIndex(t => new { t.TradeId, t.Version }).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}