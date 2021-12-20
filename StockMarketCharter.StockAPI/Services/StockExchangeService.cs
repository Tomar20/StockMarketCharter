using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.Repositories;

namespace StockMarketCharter.StockAPI.Services
{
    public class StockExchangeService : IStockExchangeService
    {
        private readonly IStockExchangeRepository stockExchangeRepository;
        public StockExchangeService(IStockExchangeRepository stockExchangeRepository)
        {
            this.stockExchangeRepository = stockExchangeRepository;
        }

        public void AddStockExchange(StockExchange stockExchange)
        {
            try
            {
                stockExchangeRepository.AddStockExchange(stockExchange);
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
                stockExchangeRepository.DeleteExchange(stockExchange);
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
               return stockExchangeRepository.GetStockExchanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
