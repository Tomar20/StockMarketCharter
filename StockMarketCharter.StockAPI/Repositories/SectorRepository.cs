using StockMarketCharter.StockAPI.DBContext;
using StockMarketCharter.StockAPI.Entities;

namespace StockMarketCharter.StockAPI.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly StockMarketCharterDBContext db; 

        public SectorRepository(StockMarketCharterDBContext db)
        {
            this.db = db;
        }
        public void AddSector(Sector sector)
        {
            try
            {
                db.Sectors.Add(sector);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteSector(Sector sector)
        {
            try
            {
                db.Sectors.Remove(sector);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Sector> GetAllSectors()
        {
            try
            {
                return db.Sectors.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
