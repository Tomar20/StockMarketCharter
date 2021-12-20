using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ExcelDataReader;
using StockMarketCharter.ReadExcelAPI.DBContext;
using StockMarketCharter.ReadExcelAPI.Entities;
using System.Web;
using System.Net.Http;
using OfficeOpenXml;
using StockMarketCharter.ReadExcelAPI.Services;

namespace StockMarketCharter.ReadExcelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadExcelController : ControllerBase
    {       

        private readonly IStockPriceService stockPriceService;

        public ReadExcelController(IStockPriceService stockPriceService)
        {
            this.stockPriceService = stockPriceService;
        }

        [HttpPost]
        [Route("ReadFile")]
        public IActionResult ReadFile()
        {

            try
            {
                var file = Request.Form.Files[0];

                var stream = file.OpenReadStream();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                /* List<StockPrice> stockPrice = new List<StockPrice>();*/
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rows = worksheet.Dimension.Rows;
                    for(var row = 2; row<=rows; row++)
                    {
                        var stockCode = worksheet.Cells[row, 1].Value?.ToString();
                        Console.WriteLine(worksheet.Cells[row, 1].Value?.ToString());
                        var stockExchangeId = worksheet.Cells[row, 2].Value?.ToString();
                        Console.WriteLine(worksheet.Cells[row, 2].Value?.ToString());
                        var currentPrice = Convert.ToInt32(worksheet.Cells[row, 3].Value);
                        Console.WriteLine(Convert.ToInt32(worksheet.Cells[row, 3].Value));
                        var dateTime = Convert.ToDateTime(worksheet.Cells[row, 4].Value);
                        Console.WriteLine(Convert.ToDateTime(worksheet.Cells[row, 4].Value));                        

                        var stockPrice = new StockPrice
                        {
                            StockCode = stockCode,
                            StockExchangeId = stockExchangeId,
                            CurrentPrice = currentPrice,
                            DateTime = dateTime
                        };
                        stockPriceService.AddStockPrice(stockPrice);                        

                    }



                }

                    return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
