using StockMarketCharter.ReadExcelAPI.Entities;

namespace StockMarketCharter.ReadExcelAPI.Repositories
{
    public interface IStockPriceRepository
    {
        void AddStockPrice(StockPrice stockprice);
    }
}
