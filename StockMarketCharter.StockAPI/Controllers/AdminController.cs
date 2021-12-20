using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketCharter.StockAPI.Services;
using StockMarketCharter.StockAPI.Entities;

namespace StockMarketCharter.StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IStockExchangeService stockExchangeService;
        private readonly ICompanyService companyService;
        private readonly ISectorService sectorService;

        public AdminController(IStockExchangeService stockExchangeService, 
            ICompanyService companyService, ISectorService sectorService)
        {
            this.stockExchangeService = stockExchangeService;
            this.companyService = companyService;
            this.sectorService = sectorService;
        }

        //===========List All Stock Exchanges =========================================


        [HttpGet]
        [Route("GetStockExchanges")]
        public IActionResult GetStockExchanges()
        {
            try
            {
                List<StockExchange> stockExchnages = stockExchangeService.GetStockExchanges();
                return Ok(stockExchnages);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddStockExchange")]
        public IActionResult AddStockExchange(StockExchange stockExchange)
        {
            try
            {
                stockExchangeService.AddStockExchange(stockExchange);
                return Ok("Stock Exchange added");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteExchange")]
        public IActionResult DeleteExchange(StockExchange stockExchange)
        {
            try
            {
                stockExchangeService.DeleteExchange(stockExchange);
                return Ok("Stock Exchange Deleted");
            }
            catch (Exception)
            {
                throw;
            }
        }
        //===========ManageCompany=========================================================

        //AddCompany
        [HttpPost]
        [Route("AddCompany")]
        public IActionResult AddCompany(Company company)
        {
            try
            {
                companyService.AddCompany(company);
                return Ok("Company Added");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Edit company
        [HttpPut]
        [Route("EditCompany")]
        public IActionResult EditCompany(Company company)
        {
            try
            {
                companyService.EditCompany(company);
                return Ok("Company Edited");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Deactivate Company
        [HttpPost]
        [Route("DeactivateCompany")]
        public IActionResult DeactivateCompany(Company company)
        {
            try
            {
                companyService.DeactivateCompany(company);
                return Ok("Company Deactivated");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //Get Companies
        [HttpGet]
        [Route("GetCompanies")]
        public IActionResult GetCompanies()
        {
            try
            {
                List<Company> companies = companyService.GetCompanies();
                return Ok(companies);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetCompany")]
        public IActionResult GetCompany(string companyId)
        {
            try
            {
                Company company = companyService.GetCompanyById(companyId);
                return Ok(company);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //==============Manage sectors===================================================

        [HttpGet]
        [Route("GetAllSectors")]
        public IActionResult GetAllSectors()
        {
            try
            {
                List<Sector> sectors = sectorService.GetAllSectors();
                return Ok(sectors);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddSector")]
        public IActionResult AddSector(Sector sector)
        {
            try
            {
                sectorService.AddSector(sector);
                return Ok("Sector Added");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DeleteSector")]
        public IActionResult DeleteSector(Sector sector)
        {
            try
            {
                sectorService.DeleteSector(sector);
                return Ok("Sector Deleted");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
