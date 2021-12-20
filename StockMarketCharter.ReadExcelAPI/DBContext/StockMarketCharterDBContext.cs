using Microsoft.EntityFrameworkCore;
using StockMarketCharter.ReadExcelAPI.Entities;
namespace StockMarketCharter.ReadExcelAPI.DBContext
{
    public class StockMarketCharterDBContext:DbContext
    {
        public StockMarketCharterDBContext(DbContextOptions<StockMarketCharterDBContext> options) : base(options)
        {

        }
        public DbSet<StockExchange> StockExchanges { get; set; }
        public DbSet<StockPrice> StockPrices { get; set; }
 
    }
}
