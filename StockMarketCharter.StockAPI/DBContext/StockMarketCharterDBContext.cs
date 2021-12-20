using Microsoft.EntityFrameworkCore;
using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.DBContext
{
    public class StockMarketCharterDBContext:DbContext
    {
        public StockMarketCharterDBContext(DbContextOptions<StockMarketCharterDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<StockExchange> StockExchanges { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
        public DbSet<IPO> IPOs { get; set; }
    }
}
