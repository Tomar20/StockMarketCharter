using StockMarketCharter.ReadExcelAPI.DBContext;
using StockMarketCharter.ReadExcelAPI.Entities;

namespace StockMarketCharter.ReadExcelAPI.Repositories
{
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly StockMarketCharterDBContext db;

        public StockPriceRepository(StockMarketCharterDBContext db)
        {
            this.db = db;
        }
        public void AddStockPrice(StockPrice stockprice)
        {
            try
            {
                db.StockPrices.Add(stockprice);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
