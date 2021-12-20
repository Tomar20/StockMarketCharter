using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockMarketCharter.AuthAPI.Entities
{
    [Table("Stock Exchange")]
    public class StockExchange
    {
        [Key]
        public string StockExchangeId    { get; set; }
        public string StockExchangeName { get; set; }    
        public string StockExchangeBrief { get; set; }
        public string StockExchangeAddress { get; set; }

        public string Remarks { get; set; }
    }
}
