using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockMarketCharter.AuthAPI.Entities
{
    [Table("Company")]
    public class Company
    {
        [Key]
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int TurnOver { get; set; }
        public string CEO { get; set; }

        public string BOD { get; set; }

        public string Brief { get; set; }
        public string StockCode { get; set; }

        [ForeignKey("Sector")]
        public string SectorId  { get; set; }

        [ForeignKey("StockExchange")]
        public string StockExchangesId { get; set; }

        public Sector? Sector { get; set; }
        public StockExchange? StockExchange { get; set; }


    }
}
