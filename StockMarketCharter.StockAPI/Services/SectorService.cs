using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.Repositories;

namespace StockMarketCharter.StockAPI.Services
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository sectorRepository;
        
        public SectorService(ISectorRepository sectorRepository)
        {
            this.sectorRepository = sectorRepository;
        }
        public void AddSector(Sector sector)
        {
            try
            {
                sectorRepository.AddSector(sector);
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
                sectorRepository.DeleteSector(sector);
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
                return sectorRepository.GetAllSectors();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
