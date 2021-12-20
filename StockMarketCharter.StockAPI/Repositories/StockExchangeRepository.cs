using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.DBContext;

namespace StockMarketCharter.StockAPI.Repositories
{
    public class StockExchangeRepository : IStockExchangeRepository
    {
        private readonly StockMarketCharterDBContext db;
        public StockExchangeRepository(StockMarketCharterDBContext db)
        {
            this.db = db;
        }

        public void AddStockExchange(StockExchange stockExchange)
        {
            try
            {
                db.StockExchanges.Add(stockExchange);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteExchange(StockExchange stockExchange)
        {
            try
            {
                db.StockExchanges.Remove(stockExchange);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<StockExchange> GetStockExchanges()
        {
            try
            {
                return db.StockExchanges.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
