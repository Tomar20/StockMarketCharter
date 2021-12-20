using StockMarketCharter.ReadExcelAPI.Entities;
using StockMarketCharter.ReadExcelAPI.Repositories;
namespace StockMarketCharter.ReadExcelAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly IStockPriceRepository stockPriceRepository;
        public StockPriceService(IStockPriceRepository stockPriceRepository)
        {
            this.stockPriceRepository = stockPriceRepository;
        }
        public void AddStockPrice(StockPrice stockprice)
        {
            try
            {
                stockPriceRepository.AddStockPrice(stockprice);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
