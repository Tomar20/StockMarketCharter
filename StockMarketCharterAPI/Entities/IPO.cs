using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockMarketCharter.AuthAPI.Entities
{
    [Table("IPO")]
    public class IPO
    {
        [Key]
        public string IPOId { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }

        [ForeignKey("StockExchange")]
        public string? StockExchangeId { get; set; }

        public int PricePerShare { get; set; }

        public int TotalNumberOfShare { get; set; }
        public DateTime DateTime { get; set; }

        /*        [Column(TypeName = "Date")]
                [DataType(DataType.Date)]
                public DateTime Date { get; set; }

                [DataType(DataType.Time)]
                public TimeSpan Time { get; set; }*/
        public string Remarks { get; set; }
        public Company? Company { get; set; }
        public StockExchange? StockExchange { get; set; }
    }
}
