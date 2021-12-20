using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Repositories
{
    public interface ICompanyRepository
    {
        void AddCompany(Company company);
        List<Company> GetCompanies();
        void EditCompany(Company company);
        void DeactivateCompany(Company company);

        Company GetCompanyById(string companyId);
    }
}
