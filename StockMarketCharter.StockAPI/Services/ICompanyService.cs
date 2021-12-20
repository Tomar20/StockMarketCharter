using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Services
{
    public interface ICompanyService
    {
        void AddCompany(Company company);
        List<Company> GetCompanies();
        void EditCompany(Company company);
        void DeactivateCompany(Company company);

        Company GetCompanyById(string id);
    }
}
