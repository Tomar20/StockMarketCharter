using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockMarketCharter.StockAPI.Entities
{
    [Table("Stock Price")]
    public class StockPrice
    {
        [Key]
        public string StockCode { get; set;}

        [ForeignKey("StockExchange")]
        public string StockExchangeId { get; set; }

        public int CurrentPrice { get; set; }

        public DateTime DateTime { get; set; }

        public StockExchange? StockExchange { get; set; }

      /*  public Company? Company { get; set; }*/


    }
}
