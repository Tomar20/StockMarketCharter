using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Repositories
{
    public interface ISectorRepository
    {
        void AddSector(Sector sector);
        void DeleteSector(Sector sector);
        List<Sector> GetAllSectors();
    }
}
