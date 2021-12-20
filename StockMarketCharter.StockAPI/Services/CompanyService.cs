using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.Repositories;

namespace StockMarketCharter.StockAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public void AddCompany(Company company)
        {
            try
            {
                companyRepository.AddCompany(company);
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
                companyRepository.DeactivateCompany(company);
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
                companyRepository.EditCompany(company);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<Company> GetCompanies()
        {
            try
            {
                return companyRepository.GetCompanies();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Company GetCompanyById(string id)
        {
            try
            {
                return companyRepository.GetCompanyById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
