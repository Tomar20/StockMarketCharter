using StockMarketCharter.StockAPI.DBContext;
using StockMarketCharter.StockAPI.Entities;

namespace StockMarketCharter.StockAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly StockMarketCharterDBContext db;

        public CompanyRepository(StockMarketCharterDBContext db)
        {
            this.db = db;
        }
        public void AddCompany(Company company)
        {
            try
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeactivateCompany(Company company)
        {
            try
            {
               /* Company company = db.Companies.SingleOrDefault(x=> x.CompanyId == companyId);*/
                db.Companies.Remove(company);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditCompany(Company company)
        {
            try
            {
                db.Companies.Update(company);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Company> GetCompanies()
        {
            try
            {
                return db.Companies.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Company GetCompanyById(string companyId)
        {
            try
            {
                Company company = db.Companies.Find(companyId);
                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
