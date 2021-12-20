using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Repositories
{
    public interface IStockExchangeRepository
    {
        List<StockExchange> GetStockExchanges();

        void AddStockExchange(StockExchange stockExchange);

        void DeleteExchange(StockExchange stockExchange);
    }
}
