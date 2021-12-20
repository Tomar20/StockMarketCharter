using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Services
{
    public interface IStockExchangeService
    {
       public List<StockExchange> GetStockExchanges();

        void AddStockExchange(StockExchange stockExchange);

        void DeleteExchange(StockExchange stockExchange);
    }
}
