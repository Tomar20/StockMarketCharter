using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Services
{
    public interface ISectorService
    {
        void AddSector(Sector sector);
        void DeleteSector(Sector sector);
        List<Sector> GetAllSectors(); 
    }
}
