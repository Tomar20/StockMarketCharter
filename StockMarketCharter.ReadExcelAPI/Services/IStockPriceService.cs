using StockMarketCharter.ReadExcelAPI.Entities;
namespace StockMarketCharter.ReadExcelAPI.Services
{
    public interface IStockPriceService
    {
        void AddStockPrice(StockPrice stockprice);
    }
}
